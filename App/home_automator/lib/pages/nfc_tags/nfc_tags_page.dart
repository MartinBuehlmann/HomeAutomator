import 'package:flutter/material.dart';
import 'package:flutter_gen/gen_l10n/app_localizations.dart';
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
  State<NfcTagsPage> createState() => _NfcTagsPageState();
}

class _NfcTagsPageState extends State<NfcTagsPage> {
  final _nfcTagNameController = TextEditingController();
  final _nfcTagIdController = TextEditingController();
  late FocusNode _nfcTagNameFocusNode;

  @override
  void initState() {
    super.initState();
    _nfcTagNameFocusNode = FocusNode();
  }

  @override
  void dispose() {
    _nfcTagIdController.dispose();
    _nfcTagNameController.dispose();
    _nfcTagNameFocusNode.dispose();

    super.dispose();
  }

  @override
  Widget build(BuildContext context) => Consumer2<NfcProvider, UrlProvider>(
        builder: (context, nfcProvider, urlProvider, _) {
          final nfcTag = nfcProvider.retrieve();
          _nfcTagIdController.text = nfcTag.tagId;
          _nfcTagNameController.text = nfcTag.tagName;
          final localizations = AppLocalizations.of(context)!;

          return Column(
            children: [
              const SizedBox(height: 36),
              SvgPicture.asset(
                'assets/icons/menu_nfc.svg',
                color: Colors.white54,
                height: 32,
              ),
              const SizedBox(height: 20),
              Text(
                localizations.nfcTagsPageLabelReadNfcTag,
                style: const TextStyle(fontSize: 15),
              ),
              const SizedBox(height: 20),
              TextFieldWidget(
                title: localizations.nfcTagsPageLabelName,
                controller: _nfcTagNameController,
                isFocussed: true,
                focusNode: _nfcTagNameFocusNode,
              ),
              TextFieldWidget(
                title: localizations.nfcTagsPageLabelNfcTag,
                controller: _nfcTagIdController,
                isEnabled: false,
              ),
              const SizedBox(height: defaultPadding),
              ButtonWidget(
                text: localizations.nfcTagsPageButtonSave,
                isEnabled: _nfcTagIdController.text.isNotEmpty,
                onPressed: () async {
                  if (_nfcTagNameController.text.isEmpty) {
                    _nfcTagNameFocusNode.requestFocus();
                    return;
                  }

                  if (_nfcTagIdController.text.isNotEmpty &&
                      _nfcTagNameController.text.isNotEmpty) {
                    await HttpClientWrapper.put(urlProvider.nfcTags, {
                      'tagId': _nfcTagIdController.text,
                      'tagName': _nfcTagNameController.text,
                    });
                  }
                },
              )
            ],
          );
        },
      );
}
