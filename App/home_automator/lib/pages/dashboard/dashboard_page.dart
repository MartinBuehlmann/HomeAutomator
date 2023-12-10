import 'package:flutter/material.dart';
import 'package:home_automator/app_state/nfc/nfc_provider.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/services/device_info/device_info_wrapper.dart';
import 'package:provider/provider.dart';

class DashboardPage extends StatefulWidget {
  const DashboardPage({Key? key}) : super(key: key);

  @override
  State<DashboardPage> createState() => _DashboardPageState();
}

class _DashboardPageState extends State<DashboardPage> {
  @override
  Widget build(BuildContext context) => Consumer2<NfcProvider, UrlProvider>(
        builder: (context, nfcProvider, urlProvider, _) =>
            FutureBuilder<String>(
          future: DeviceInfoWrapper.retrieveDeviceId(),
          builder: (context, snapshot) {
            if (snapshot.hasData) {
              final nfcTag = nfcProvider.retrieve();
              if (nfcTag.tagId != '') {
                HttpClientWrapper.put(
                  urlProvider.automator,
                  {
                    'deviceId': snapshot.data,
                    'tagId': nfcTag.tagId,
                  },
                );
              }
              return Column(
                children: const [],
              );
            } else {
              return const Center(
                child: CircularProgressIndicator(),
              );
            }
          },
        ),
      );
}
