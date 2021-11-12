import 'package:home_automator/services/communication/http_client_wrapper.dart';

class UrlProvider {
  String _devices = '';
  String _nfcTags = '';

  String get devices => _devices;
  String get nfcTags => _nfcTags;

  Future<void> load(String backendUrl) async {
    final urls = await HttpClientWrapper.get('http://' + backendUrl + '/api');
    _devices = urls['devices']['href'];
    _nfcTags = urls['nfcTags']['href'];
  }
}
