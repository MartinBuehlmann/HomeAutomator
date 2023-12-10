import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/pages/settings/light.dart';
import 'package:home_automator/pages/settings/lights_mapper.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';

class LightsRetriever {
  LightsRetriever(this.urlProvider);

  final UrlProvider urlProvider;

  Future<List<Light>> retrieveLights() async {
    final lights = await HttpClientWrapper.get(urlProvider.lights);
    return LightsMapper.mapList(lights.toList());
  }
}
