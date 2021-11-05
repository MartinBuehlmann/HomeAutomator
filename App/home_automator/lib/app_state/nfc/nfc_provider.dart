import 'package:flutter/cupertino.dart';
import 'package:nfc_manager/nfc_manager.dart';

class NfcProvider extends ChangeNotifier {
  String _tagId = '';

  String get tagId => _tagId;

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

        if (tagId != _tagId) {
          _tagId = tagId;
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
