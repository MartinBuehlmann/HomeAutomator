import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/services/device_info/device_info_wrapper.dart';
import 'package:home_automator/services/store/secure_storage_wrapper.dart';

class AuthProvider extends ChangeNotifier {
  bool _isLoggingIn = false;
  bool _isLoggedIn = false;

  bool get isLoggingIn => _isLoggingIn;

  bool get isLoggedIn => _isLoggedIn;

  Future<void> signInAutomatically() async {
    final backendAddress = await SecureStorageWrapper.retrieveBackendAddress();

    if (backendAddress == null) {
      return;
    }

    final deviceId = await DeviceInfoWrapper.retrieveDeviceId();

    final response = await await HttpClientWrapper.head(
        'http://' + backendAddress + ':5000/api/Devices/' + deviceId);

    if (response.statusCode == 200) {
      _isLoggedIn = true;
    } else {
      _isLoggedIn = false;
    }

    notifyListeners();
  }

  Future<void> signIn(String backendAddress) async {
    try {
      _isLoggingIn = true;
      notifyListeners();

      final deviceId = await DeviceInfoWrapper.retrieveDeviceId();

      final response = await HttpClientWrapper.put(
        'http://' + backendAddress + ':5000/api/Devices',
        {'deviceId': deviceId},
      );

      if (response.statusCode == 200) {
        _isLoggedIn = true;
        await SecureStorageWrapper.saveBackendAddress(backendAddress);
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
    notifyListeners();
  }
}
