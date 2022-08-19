import 'package:home_automator/services/communication/http_client_wrapper.dart';

class UrlProvider {
  String _automator = '';
  String _devices = '';
  String _nfcTags = '';
  String _settings = '';
  String _lights = '';

  String get automator => _automator;
  String get devices => _devices;
  String get nfcTags => _nfcTags;
  String get settings => _settings;
  String get lights => _lights;

  Future<void> load(String backendUrl) async {
    final urls = await HttpClientWrapper.get('http://$backendUrl/api');
    _automator = urls['automator']['href'];
    _devices = urls['devices']['href'];
    _nfcTags = urls['nfcTags']['href'];
    _settings = urls['settings']['href'];
    _lights = urls['lights']['href'];
  }
}
