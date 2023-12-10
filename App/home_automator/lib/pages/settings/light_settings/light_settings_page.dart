import 'package:flutter/material.dart';
import 'package:flutter_circle_color_picker/flutter_circle_color_picker.dart';
import 'package:flutter_gen/gen_l10n/app_localizations.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/pages/settings/light.dart';
import 'package:home_automator/routes.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/services/device_info/device_info_wrapper.dart';
import 'package:home_automator/utilities/hex_color.dart';
import 'package:home_automator/widgets/label_widget.dart';
import 'package:provider/provider.dart';

class LightSettingsPage extends StatefulWidget {
  const LightSettingsPage({Key? key}) : super(key: key);

  @override
  _LightSettingsPageState createState() => _LightSettingsPageState();
}

class _LightSettingsPageState extends State<LightSettingsPage> {
  LightSettingsData? _lightSettingsData;
  final _controller = CircleColorPickerController(
    initialColor: Colors.black,
  );

  @override
  Widget build(BuildContext context) {
    _lightSettingsData =
        ModalRoute.of(context)!.settings.arguments as LightSettingsData;
    _controller.color = HexColor.fromHex(_lightSettingsData!.light.color);
    final localizations = AppLocalizations.of(context)!;
    return Consumer<UrlProvider>(
      builder: (context, urlProvider, _) => Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Container(
            margin: const EdgeInsets.fromLTRB(0, 1, 0, 1),
            padding: const EdgeInsets.all(10),
            decoration: BoxDecoration(
              border: Border.all(
                color: Colors.black,
              ),
              color: Colors.white10,
              borderRadius: const BorderRadius.all(
                Radius.circular(5),
              ),
            ),
            child: Column(
              children: [
                Row(
                  children: [
                    Expanded(
                      child: LabelWidget(
                        text: _lightSettingsData!.light.name,
                      ),
                    ),
                    Switch(
                      activeColor:
                          Theme.of(context).buttonTheme.colorScheme!.primary,
                      value: _lightSettingsData!.light.on,
                      onChanged: (isOn) {
                        setState(() {
                          _lightSettingsData!.light.on = isOn;
                          _setLight(urlProvider, _lightSettingsData!.light);
                        });
                      },
                    )
                  ],
                ),
                Slider(
                  min: 0.0,
                  max: 100.0,
                  divisions: 100,
                  value: _lightSettingsData!.light.brightness.toDouble(),
                  onChanged: (value) {},
                  onChangeEnd: (value) {
                    setState(() {
                      _lightSettingsData!.light.brightness = value.toInt();
                      _setLight(urlProvider, _lightSettingsData!.light);
                    });
                  },
                ),
              ],
            ),
          ),
          const SizedBox(
            height: 20,
          ),
          Center(
            child: CircleColorPicker(
              textStyle: const TextStyle(color: Colors.transparent),
              strokeWidth: 10,
              thumbSize: 48,
              controller: _controller,
              onEnded: (color) async {
                setState(() {
                  _lightSettingsData!.light.color =
                      color.toHex(leadingHashSign: false);
                });
                await _setLight(urlProvider, _lightSettingsData!.light);
              },
            ),
          ),
          const SizedBox(
            height: 20,
          ),
          Center(
            child: ElevatedButton(
              child: Text(localizations.lightSelectionPageLabelAcceptButton),
              onPressed: () async {
                await HttpClientWrapper.put(
                    urlProvider.settings +
                        '/' +
                        _lightSettingsData!.tagId +
                        '/' +
                        await DeviceInfoWrapper.retrieveDeviceId() +
                        '/' +
                        _lightSettingsData!.light.id,
                    {
                      'id': _lightSettingsData!.light.id,
                      'isOn': _lightSettingsData!.light.on,
                      'color': _lightSettingsData!.light.color.substring(
                          _lightSettingsData!.light.color.length - 6),
                      'brightness': _lightSettingsData!.light.brightness
                    });
                Navigator.of(context).pushReplacementNamed(
                  Routes.settings,
                  arguments: _lightSettingsData!.tagId,
                );
              },
            ),
          ),
        ],
      ),
    );
  }

  Future _setLight(UrlProvider urlProvider, Light light) async {
    await HttpClientWrapper.put(urlProvider.lights + '/' + light.id, {
      'isOn': light.on,
      'color': light.color.substring(light.color.length - 6),
      'brightness': light.brightness
    });
  }
}

class LightSettingsData {
  LightSettingsData(this.tagId, this.light);

  final String tagId;
  final Light light;
}
