import 'package:flutter/cupertino.dart';
import 'package:home_automator/app_state/nfc/nfc_tag_data.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/services/communication/http_request_exception.dart';
import 'package:nfc_manager/nfc_manager.dart';

class NfcProvider extends ChangeNotifier {
  NfcProvider(this._urlProvider);

  final UrlProvider _urlProvider;
  NfcTagData _nfcTag = NfcTagData('', '');

  NfcTagData retrieve() {
    final nfcTag = _nfcTag;
    _nfcTag = NfcTagData('', '');
    return nfcTag;
  }

  Future initialize() async {
    if (await NfcManager.instance.isAvailable()) {
      NfcManager.instance.startSession(onDiscovered: (NfcTag tag) async {
        var tagId = '';

        var ndefTag = Ndef.from(tag);
        if (ndefTag != null) {
          tagId = ndefTag.additionalData['identifier']
              .map((e) => e.toRadixString(16).padLeft(2, '0').toUpperCase())
              .join('-')
              .toString();
        }

        if (tagId != _nfcTag.tagId) {
          try {
            final loadedNfcTag =
                await HttpClientWrapper.get('${_urlProvider.nfcTags}/$tagId');

            if (loadedNfcTag.isEmpty) {
              _nfcTag = NfcTagData(tagId, '');
            } else {
              _nfcTag =
                  NfcTagData(loadedNfcTag['tagId'], loadedNfcTag['tagName']);
            }
          } on HttpRequestException {
            _nfcTag = NfcTagData(tagId, '');
          }
          notifyListeners();
        }
      });
    }
  }

  Future uninitialize() async {
    if (await NfcManager.instance.isAvailable()) {
      NfcManager.instance.stopSession();
    }
  }
}
