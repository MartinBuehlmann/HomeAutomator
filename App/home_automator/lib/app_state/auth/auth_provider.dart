import 'package:flutter/material.dart';
import 'package:home_automator/app_state/nfc/nfc_provider.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/services/device_info/device_info_wrapper.dart';
import 'package:home_automator/services/store/secure_storage_wrapper.dart';

class AuthProvider extends ChangeNotifier {
  AuthProvider(this._urlProvider, this._nfcProvider);

  final UrlProvider _urlProvider;
  final NfcProvider _nfcProvider;

  bool _isLoggingIn = false;
  bool _isLoggedIn = false;

  bool get isLoggingIn => _isLoggingIn;

  bool get isLoggedIn => _isLoggedIn;

  Future<void> signInAutomatically() async {
    final backendAddress = await SecureStorageWrapper.retrieveBackendAddress();

    if (backendAddress == null) {
      return;
    }

    await _urlProvider.load(backendAddress);

    final deviceId = await DeviceInfoWrapper.retrieveDeviceId();
    final response = await await HttpClientWrapper.head(
        _urlProvider.devices + '/' + deviceId);

    if (response.statusCode == 200) {
      _isLoggedIn = true;
      _nfcProvider.initialize();
    } else {
      _isLoggedIn = false;
    }

    notifyListeners();
  }

  Future<void> signIn(String backendAddress) async {
    try {
      _isLoggingIn = true;
      notifyListeners();

      await _urlProvider.load(backendAddress);
      final deviceId = await DeviceInfoWrapper.retrieveDeviceId();
      final deviceName = await DeviceInfoWrapper.retrieveDeviceName();
      final response = await HttpClientWrapper.put(
        _urlProvider.devices,
        {
          'deviceId': deviceId,
          'deviceName': deviceName,
        },
      );

      if (response.statusCode == 200) {
        _isLoggedIn = true;
        await SecureStorageWrapper.saveBackendAddress(backendAddress);
        _nfcProvider.initialize();
      } else {
        await SecureStorageWrapper.deleteBackendUrl();
        _isLoggedIn = false;
      }
    } finally {
      _isLoggingIn = false;
      notifyListeners();
    }
  }

  Future<void> signOut() async {
    await SecureStorageWrapper.deleteBackendUrl();
    _isLoggedIn = false;
    _nfcProvider.uninitialize();
    notifyListeners();
  }
}
