import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:home_automator/pages/settings/light.dart';
import 'package:home_automator/pages/settings/light_settings/light_settings_page.dart';
import 'package:home_automator/utilities/hex_color.dart';
import 'package:home_automator/routes.dart';

class ConfigurableLightWidget extends StatelessWidget {
  const ConfigurableLightWidget(this.tagId, this.light, {Key? key})
      : super(key: key);

  final String tagId;
  final Light light;

  @override
  Widget build(BuildContext context) => GestureDetector(
        onTap: () => Navigator.of(context).pushNamed(Routes.lightSettings,
            arguments: LightSettingsData(tagId, light)),
        child: Container(
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
          child: Row(
            children: [
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      light.name,
                      style: const TextStyle(
                        fontWeight: FontWeight.normal,
                        fontSize: 16,
                      ),
                    ),
                    Text(light.roomName),
                  ],
                ),
              ),
              Icon(light.on
                  ? CupertinoIcons.lightbulb_fill
                  : CupertinoIcons.lightbulb_slash),
              const SizedBox(
                width: 10,
              ),
              Container(
                decoration: BoxDecoration(
                  border: Border.all(
                    color: Colors.black,
                  ),
                  color: HexColor.fromHex(light.color),
                  borderRadius: const BorderRadius.all(
                    Radius.circular(5),
                  ),
                ),
                height: 40,
                width: 40,
                child: Center(
                  child: Text(light.brightness.toString() + '%'),
                ),
              ),
            ],
          ),
        ),
      );
}
