import 'package:home_automator/pages/settings/light_settings.dart';

class LightSettingsMapper {
  static LightSettings map(dynamic value) => LightSettings(
        value['id'],
        value['on'],
        value['color'],
        value['brightness'],
        value['light']['href'],
      );

  static List<LightSettings> mapList(dynamic value) => List<LightSettings>.from(
        value.map(
          (x) => LightSettingsMapper.map(x),
        ),
      );
}
