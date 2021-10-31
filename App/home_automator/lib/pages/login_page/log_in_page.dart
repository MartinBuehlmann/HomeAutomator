import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:home_automator/app_state/auth/auth_provider.dart';
import 'package:provider/provider.dart';

class LogInPage extends StatefulWidget {
  const LogInPage({Key? key, this.title}) : super(key: key);

  final String? title;

  @override
  _LogInPageState createState() => _LogInPageState();
}

class _LogInPageState extends State<LogInPage> {
  final deviceAddressController = TextEditingController();

  Widget _title() {
    return RichText(
      textAlign: TextAlign.center,
      text: const TextSpan(children: [
        TextSpan(
          text: 'Home',
          style: TextStyle(color: Colors.white, fontSize: 30),
        ),
        TextSpan(
          text: 'Automator',
          style: TextStyle(color: Color(0xffe46b10), fontSize: 30),
        ),
      ]),
    );
  }

  Widget _entryField(String title,
      {bool isPassword = false, bool isFocussed = false}) {
    return Container(
      margin: const EdgeInsets.symmetric(vertical: 10),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          Text(
            title,
            style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
          ),
          const SizedBox(
            height: 10,
          ),
          TextField(
              autofocus: isFocussed,
              style: const TextStyle(color: Colors.black),
              controller: deviceAddressController,
              obscureText: isPassword,
              decoration: const InputDecoration(
                  border: InputBorder.none,
                  fillColor: Color(0xfff3f3f4),
                  filled: true))
        ],
      ),
    );
  }

  Widget _ipAddressWidget() {
    return Column(
      children: <Widget>[
        _entryField("IP Address", isFocussed: true),
      ],
    );
  }

  Widget _submitButton(AuthProvider auth) {
    return GestureDetector(
      onTap: () => auth.signIn(deviceAddressController.text),
      child: Container(
        width: MediaQuery.of(context).size.width,
        padding: const EdgeInsets.symmetric(vertical: 10),
        alignment: Alignment.center,
        decoration: const BoxDecoration(
            borderRadius: BorderRadius.all(Radius.circular(5)),
            boxShadow: <BoxShadow>[
              BoxShadow(
                  color: Colors.black,
                  offset: Offset(2, 4),
                  blurRadius: 5,
                  spreadRadius: 2)
            ],
            gradient: LinearGradient(
                begin: Alignment.centerLeft,
                end: Alignment.centerRight,
                colors: [Color(0xfffbb448), Color(0xfff7892b)])),
        child: const Text(
          'Login',
          style: TextStyle(fontSize: 20, color: Colors.white),
        ),
      ),
    );
  }

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
                      _title(),
                      const SizedBox(height: 50),
                      _ipAddressWidget(),
                      const SizedBox(height: 20),
                      _submitButton(auth),
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
