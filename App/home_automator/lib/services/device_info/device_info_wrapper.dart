import 'dart:io';

import 'package:device_info_plus/device_info_plus.dart';

mixin DeviceInfoWrapper {
  static final _deviceInfoPlugin = DeviceInfoPlugin();

  static Future<String> retrieveDeviceId() async {
    String? deviceId;
    if (Platform.isAndroid) {
      var info = await _deviceInfoPlugin.androidInfo;
      deviceId = info.androidId;
    } else if (Platform.isIOS) {
      var info = await _deviceInfoPlugin.iosInfo;
      deviceId = info.identifierForVendor;
    } else {
      throw Exception('Unsupported operation system.');
    }

    if (deviceId == null) {
      throw Exception('DeviceId is null');
    }

    return deviceId;
  }
}
