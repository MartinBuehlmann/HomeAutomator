import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class TextFieldWidget extends StatelessWidget {
  const TextFieldWidget({
    Key? key,
    this.isPassword = false,
    this.isFocussed = false,
    this.isEnabled = true,
    required this.title,
    required this.controller,
  }) : super(key: key);

  final bool isPassword;
  final bool isFocussed;
  final bool isEnabled;
  final String title;
  final TextEditingController controller;

  @override
  Widget build(BuildContext context) => Container(
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
                enabled: isEnabled,
                style: const TextStyle(color: Colors.black),
                controller: controller,
                obscureText: isPassword,
                decoration: const InputDecoration(
                    border: InputBorder.none,
                    fillColor: Color(0xfff3f3f4),
                    filled: true))
          ],
        ),
      );
}
