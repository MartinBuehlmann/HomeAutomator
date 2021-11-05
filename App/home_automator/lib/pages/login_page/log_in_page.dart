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
        body: SizedBox(
          height: height,
          child: Stack(
            children: <Widget>[
              Positioned(
                  top: -height * .15,
                  right: -MediaQuery.of(context).size.width * .4,
                  child: Container()),
              Container(
                padding: const EdgeInsets.symmetric(horizontal: 20),
                child: SingleChildScrollView(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: <Widget>[
                      SizedBox(height: height * .2),
                      const AppNameWidget(30),
                      const SizedBox(height: 30),
                      TextFieldWidget(
                        title: 'Netzwerk Adresse',
                        controller: deviceAddressController,
                        isFocussed: true,
                      ),
                      const SizedBox(height: 20),
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
    );
  }
}
