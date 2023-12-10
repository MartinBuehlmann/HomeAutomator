import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/pages/settings/light_settings.dart';
import 'package:home_automator/pages/settings/light_settings_mapper.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/services/device_info/device_info_wrapper.dart';

class AssignedLightSettingsRetriever {
  AssignedLightSettingsRetriever(this.urlProvider);

  final UrlProvider urlProvider;

  Future<List<LightSettings>> retrieveAssignedLightSettings(
      String tagId) async {
    final retrievedAssignedLights = await HttpClientWrapper.get(
        urlProvider.settings +
            '/' +
            tagId +
            '/' +
            await DeviceInfoWrapper.retrieveDeviceId());
    return LightSettingsMapper.mapList(retrievedAssignedLights as List);
  }
}
