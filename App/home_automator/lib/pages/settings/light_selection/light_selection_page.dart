import 'package:flutter/material.dart';
import 'package:flutter_gen/gen_l10n/app_localizations.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/pages/settings/assigner_light_settings_retriever.dart';
import 'package:home_automator/pages/settings/light_selection/selectable_light.dart';
import 'package:home_automator/pages/settings/light_selection/selectable_light_widget.dart';
import 'package:home_automator/pages/settings/light_settings.dart';
import 'package:home_automator/pages/settings/lights_mapper.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/services/device_info/device_info_wrapper.dart';
import 'package:provider/provider.dart';

class LightSelectionPage extends StatefulWidget {
  const LightSelectionPage({Key? key}) : super(key: key);

  @override
  _LightSelectionPageState createState() => _LightSelectionPageState();
}

class _LightSelectionPageState extends State<LightSelectionPage> {
  String tagId = '';

  @override
  Widget build(BuildContext context) {
    tagId = ModalRoute.of(context)!.settings.arguments as String;
    final localizations = AppLocalizations.of(context)!;
    return Consumer<UrlProvider>(
      builder: (context, urlProvider, _) =>
          FutureBuilder<List<SelectableLight>>(
        future: _retrieveAllLights(urlProvider, tagId),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            return Column(
              children: [
                Column(children: _buildItems(snapshot.data!)),
                ElevatedButton(
                  child:
                      Text(localizations.lightSelectionPageLabelAcceptButton),
                  onPressed: () async {
                    final selectedLightSettings = List.from(
                      snapshot.data!.where((element) => element.selected).map(
                            (e) => {
                              'id': e.light.id,
                              'on': e.light.on,
                              'color': e.light.color,
                              'brightness': e.light.brightness
                            },
                          ),
                    );
                    await HttpClientWrapper.put(
                        urlProvider.settings +
                            '/' +
                            tagId +
                            '/' +
                            await DeviceInfoWrapper.retrieveDeviceId(),
                        selectedLightSettings);
                    Navigator.of(context).pop();
                  },
                ),
              ],
            );
          } else {
            return const Center(
              child: CircularProgressIndicator(),
            );
          }
        },
      ),
    );
  }

  Future<List<SelectableLight>> _retrieveAllLights(
    UrlProvider urlProvider,
    String tagid,
  ) async {
    final lights = await HttpClientWrapper.get(urlProvider.lights);
    final assignedLightsRetriever = AssignedLightSettingsRetriever(urlProvider);
    final assignedLights =
        await assignedLightsRetriever.retrieveAssignedLightSettings(tagId);
    return List<SelectableLight>.from(
      lights.map(
        (x) => SelectableLight(
          assignedLights.any((element) => element.id == x['id']),
          LightsMapper.map(x),
        ),
      ),
    )..sort((a, b) => a.light.name.compareTo(b.light.name));
  }

  List<Widget> _buildItems(List<SelectableLight> lights) =>
      lights.map((e) => SelectableLightWidget(e)).toList();
}
