import 'package:flutter/material.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/widgets/combo_box_widget.dart';
import 'package:provider/provider.dart';

class SettingsPage extends StatefulWidget {
  const SettingsPage({Key? key}) : super(key: key);

  @override
  _SettingsPageState createState() => _SettingsPageState();
}

class _SettingsPageState extends State<SettingsPage> {
  DropdownItem? currentItem;

  @override
  Widget build(BuildContext context) => Consumer<UrlProvider>(
        builder: (context, urlProvider, _) => FutureBuilder<List<DropdownItem>>(
          future: _retrieveNfcTagsDropdownItems(urlProvider),
          builder: (context, snapshot) {
            if (snapshot.hasData) {
              return Column(
                children: [
                  ComboBoxWidget(
                    title: 'Bereich (NFC Tag)',
                    items: snapshot.data!,
                    value: currentItem,
                    onChanged: (DropdownItem? newValue) => setState(
                      () {
                        currentItem = newValue;
                      },
                    ),
                  )
                ],
              );
            } else {
              return Container();
              //BusyIndicatorWidget();
            }
          },
        ),
      );

  Future<List<DropdownItem>> _retrieveNfcTagsDropdownItems(
      UrlProvider urlProvider) async {
    final nfcTags = await HttpClientWrapper.get(urlProvider.nfcTags);
    return (nfcTags as List)
        .map((x) => DropdownItem(x['tagName'], x['tagId']))
        .toList();
  }
}
