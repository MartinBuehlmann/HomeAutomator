import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:home_automator/app_state/auth/auth_provider.dart';
import 'package:home_automator/widgets/app_name_widget.dart';
import 'package:home_automator/widgets/button_widget.dart';
import 'package:home_automator/widgets/text_field_widget.dart';
import 'package:provider/provider.dart';

class LogInPage extends StatefulWidget {
  const LogInPage({Key? key}) : super(key: key);

  @override
  _LogInPageState createState() => _LogInPageState();
}

class _LogInPageState extends State<LogInPage> {
  final deviceAddressController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    final height = MediaQuery.of(context).size.height;
    return Consumer<AuthProvider>(
      builder: (context, auth, _) => Scaffold(
        body: SafeArea(
          child: SizedBox(
            height: height,
            child: Stack(
              children: <Widget>[
                Container(
                  padding: const EdgeInsets.symmetric(horizontal: 20),
                  child: SingleChildScrollView(
                    child: Column(
                      children: [
                        SizedBox(height: height * .15),
                        const AppNameWidget(30),
                        SizedBox(height: height * .07),
                        TextFieldWidget(
                          title: 'Netzwerk Adresse',
                          controller: deviceAddressController,
                          isFocussed: true,
                        ),
                        const SizedBox(height: 16),
                        ButtonWidget(
                          text: 'Verbinden',
                          onPressed: () =>
                              auth.signIn(deviceAddressController.text),
                        )
                      ],
                    ),
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
