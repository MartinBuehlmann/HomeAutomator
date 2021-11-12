import 'package:flutter/material.dart';
import 'package:home_automator/app_state/nfc/nfc_provider.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/services/communication/http_request_exception.dart';
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

    try {
      await _urlProvider.load(backendAddress);

      final deviceId = await DeviceInfoWrapper.retrieveDeviceId();
      await HttpClientWrapper.head(_urlProvider.devices + '/' + deviceId);

      _isLoggedIn = true;
      _nfcProvider.initialize();
    } on HttpRequestException {
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
      await HttpClientWrapper.put(
        _urlProvider.devices,
        {
          'deviceId': deviceId,
          'deviceName': deviceName,
        },
      );

      _isLoggedIn = true;
      await SecureStorageWrapper.saveBackendAddress(backendAddress);
      _nfcProvider.initialize();
    } on HttpRequestException {
      await SecureStorageWrapper.deleteBackendUrl();
      _isLoggedIn = false;
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
