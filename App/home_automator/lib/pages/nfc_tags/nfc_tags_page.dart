import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:home_automator/app_state/nfc/nfc_provider.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/constants.dart';
import 'package:home_automator/services/communication/http_client_wrapper.dart';
import 'package:home_automator/widgets/button_widget.dart';
import 'package:home_automator/widgets/text_field_widget.dart';
import 'package:provider/provider.dart';

class NfcTagsPage extends StatefulWidget {
  const NfcTagsPage({Key? key}) : super(key: key);

  @override
  _NfcTagsPageState createState() => _NfcTagsPageState();
}

class _NfcTagsPageState extends State<NfcTagsPage> {
  final nfcTagNameController = TextEditingController();
  final nfcTagIdController = TextEditingController();

  @override
  void dispose() {
    nfcTagIdController.dispose();
    nfcTagNameController.dispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) => Consumer2<NfcProvider, UrlProvider>(
          builder: (context, nfc, urlProvider, _) {
        nfcTagIdController.text = nfc.tagId;

        return SafeArea(
          child: SingleChildScrollView(
            padding: const EdgeInsets.all(defaultPadding),
            child: Column(
              children: [
                const SizedBox(height: defaultPadding),
                Row(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Expanded(
                      flex: 5,
                      child: Column(
                        children: [
                          const SizedBox(height: 20),
                          SvgPicture.asset(
                            'assets/icons/menu_nfc.svg',
                            color: Colors.white54,
                            height: 32,
                          ),
                          const SizedBox(height: 20),
                          const Text(
                            'NFC Tag berühren',
                            style: TextStyle(fontSize: 15),
                          ),
                          const SizedBox(height: 20),
                          TextFieldWidget(
                            title: 'Name',
                            controller: nfcTagNameController,
                            isFocussed: true,
                          ),
                          TextFieldWidget(
                            title: 'NFC Tag',
                            controller: nfcTagIdController,
                            isEnabled: false,
                          ),
                          const SizedBox(height: 20),
                          ButtonWidget(
                            text: 'Speichern',
                            isEnabled: nfcTagIdController.text.isNotEmpty &&
                                nfcTagNameController.text.isNotEmpty,
                            onPressed: () => {
                              HttpClientWrapper.put(urlProvider.nfcTags, {
                                'tagId': nfcTagIdController.text,
                                'tagName': nfcTagNameController.text,
                              })
                            },
                          )
                        ],
                      ),
                    ),
                  ],
                )
              ],
            ),
          ),
        );
      });
}
