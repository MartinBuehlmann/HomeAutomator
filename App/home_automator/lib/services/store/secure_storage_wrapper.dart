import 'package:flutter_secure_storage/flutter_secure_storage.dart';

mixin SecureStorageWrapper {
  static const String _storageBackendAddressKey = 'backendAddress';

  static const _storage = FlutterSecureStorage();

  static Future saveBackendAddress(String backendAddress) async {
    await _storage.write(key: _storageBackendAddressKey, value: backendAddress);
  }

  static Future<String?> retrieveBackendAddress() =>
      _storage.read(key: _storageBackendAddressKey);

  static Future deleteBackendUrl() async {
    await _storage.delete(key: _storageBackendAddressKey);
  }
}
