import 'package:flutter/material.dart';
import 'package:flutter_circle_color_picker/flutter_circle_color_picker.dart';
import 'package:flutter_gen/gen_l10n/app_localizations.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/pages/settings/light.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/services/device_info/device_info_wrapper.dart';
import 'package:home_automator/utilities/hex_color.dart';
import 'package:home_automator/widgets/label_widget.dart';
import 'package:input_slider/input_slider.dart';
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
          LabelWidget(
            text: _lightSettingsData!.light.name,
          ),
          const SizedBox(
            height: 40,
          ),
          Center(
            child: CircleColorPicker(
              textStyle: const TextStyle(color: Colors.transparent),
              strokeWidth: 10,
              thumbSize: 48,
              controller: _controller,
              onChanged: (color) {
                setState(
                  () => _lightSettingsData!.light.color =
                      color.toHex(leadingHashSign: false),
                );
              },
            ),
          ),
          const SizedBox(
            height: 20,
          ),
          Center(
            child: InputSlider(
              onChange: (value) {
                setState(() {
                  _lightSettingsData!.light.brightness = value.toInt();
                });
              },
              min: 0.0,
              max: 100.0,
              decimalPlaces: 0,
              defaultValue: _lightSettingsData!.light.brightness.toDouble(),
              activeSliderColor: Colors.white,
              inactiveSliderColor: Colors.white60,
              leading: LabelWidget(
                text: localizations.lightSettingsPageLabelBrightness,
              ),
            ),
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
                      'on': _lightSettingsData!.light.on,
                      'color': _lightSettingsData!.light.color,
                      'brightness': _lightSettingsData!.light.brightness
                    });
                Navigator.of(context).pop();
              },
            ),
          ),
        ],
      ),
    );
  }
}

class LightSettingsData {
  LightSettingsData(this.tagId, this.light);

  final String tagId;
  final Light light;
}
