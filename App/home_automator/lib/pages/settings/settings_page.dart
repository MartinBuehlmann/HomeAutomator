import 'package:dart_extensions/dart_extensions.dart';
import 'package:flutter/material.dart';
import 'package:flutter_gen/gen_l10n/app_localizations.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/pages/settings/assigner_light_settings_retriever.dart';
import 'package:home_automator/pages/settings/configurable_lights_widget.dart';
import 'package:home_automator/pages/settings/light.dart';
import 'package:home_automator/pages/settings/light_settings.dart';
import 'package:home_automator/pages/settings/lights_retriever.dart';
import 'package:home_automator/routes.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/widgets/combo_box_widget.dart';
import 'package:home_automator/widgets/label_widget.dart';
import 'package:provider/provider.dart';

// TODO: check route for tagId and select it
class SettingsPage extends StatefulWidget {
  const SettingsPage({Key? key}) : super(key: key);

  @override
  State<SettingsPage> createState() => _SettingsPageState();
}

class _SettingsPageState extends State<SettingsPage> {
  DropdownItem? currentItem;

  @override
  Widget build(BuildContext context) {
    final localizations = AppLocalizations.of(context)!;
    return Consumer<UrlProvider>(
      builder: (context, urlProvider, _) => FutureBuilder<SettingsData>(
        future: _retrieveAppConfiguration(urlProvider, currentItem?.value),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            currentItem ??= snapshot.data!.tagDropdownItems.firstOrNull;
            return Column(
              children: [
                ComboBoxWidget(
                  title: localizations.settingsPageLabelArea,
                  items: snapshot.data!.tagDropdownItems,
                  value: currentItem,
                  onChanged: (DropdownItem? newValue) => setState(
                    () {
                      currentItem = newValue;
                    },
                  ),
                ),
                Row(
                  children: [
                    LabelWidget(text: localizations.settingsPageLabelLights),
                    const Spacer(),
                    ElevatedButton(
                      onPressed: () {
                        Navigator.of(context).pushNamed(
                          Routes.lightSelection,
                          arguments: _retrieveCurrentValue(
                              snapshot.data!.tagDropdownItems),
                        );
                      },
                      child: Text(localizations.settingsPageLabelAddButton),
                    ),
                  ],
                ),
                Column(
                  children: _buildItems(
                    currentItem?.value,
                    snapshot.data!.lights,
                  ),
                )
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

  Future<SettingsData> _retrieveAppConfiguration(
    UrlProvider urlProvider,
    String? tagId,
  ) async {
    final nfcTags = await HttpClientWrapper.get(urlProvider.nfcTags);
    final tagDropdownItems = (nfcTags as List)
        .map((x) => DropdownItem(x['tagName'], x['tagId']))
        .toList();

    List<LightSettings> lightSettings = <LightSettings>[];
    tagId ??= tagDropdownItems.firstOrNull?.value;

    if (tagId != null) {
      final assignedLightSettingsRetriever =
          AssignedLightSettingsRetriever(urlProvider);
      final retrievedLights = await assignedLightSettingsRetriever
          .retrieveAssignedLightSettings(tagId);
      lightSettings.addAll(retrievedLights);
    }

    final lightsRetriever = LightsRetriever(urlProvider);
    final allLights = await lightsRetriever.retrieveLights();
    final lights = lightSettings.map((e) {
      Light light = allLights.where((x) => x.id == e.id).single;
      return Light(
        e.id,
        light.name,
        e.on,
        e.color,
        e.brightness,
        true,
        light.roomName,
        light.self,
      );
    }).toList();

    return SettingsData(tagDropdownItems, lights);
  }

  String? _retrieveCurrentValue(List<DropdownItem> tagDropdownItems) {
    if (currentItem != null) {
      return currentItem!.value;
    } else if (tagDropdownItems.isNotEmpty) {
      return tagDropdownItems.first.value;
    }

    return null;
  }

  _buildItems(String? tagId, List<Light> lights) =>
      lights.map((light) => ConfigurableLightWidget(tagId!, light)).toList();
}

class SettingsData {
  const SettingsData(this.tagDropdownItems, this.lights);

  final List<DropdownItem> tagDropdownItems;
  final List<Light> lights;
}
