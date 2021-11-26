import 'package:home_automator/pages/settings/light.dart';

class LightsMapper {
  static Light map(dynamic value) => Light(
        value['id'],
        value['name'],
        value['on'],
        value['color'],
        value['brightness'],
        value['isReachable'],
        value['roomName'],
        value['self']['href'],
      );

  static List<Light> mapList(dynamic value) => List<Light>.from(
        value.map(
          (x) => LightsMapper.map(x),
        ),
      );
}
