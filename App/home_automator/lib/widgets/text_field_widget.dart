import 'package:flutter/material.dart';

class TextFieldWidget extends StatelessWidget {
  const TextFieldWidget({
    Key? key,
    this.isPassword = false,
    this.isFocussed = false,
    this.isEnabled = true,
    this.focusNode,
    required this.title,
    required this.controller,
  }) : super(key: key);

  final bool isPassword;
  final bool isFocussed;
  final bool isEnabled;
  final FocusNode? focusNode;
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
              style:
                  const TextStyle(fontWeight: FontWeight.normal, fontSize: 16),
            ),
            const SizedBox(
              height: 7,
            ),
            TextField(
              autofocus: isFocussed,
              enabled: isEnabled,
              style: const TextStyle(color: Colors.black),
              controller: controller,
              obscureText: isPassword,
              focusNode: focusNode,
              decoration: InputDecoration(
                  isDense: true,
                  border: InputBorder.none,
                  fillColor: isEnabled ? Colors.white : Colors.white54,
                  filled: true),
            )
          ],
        ),
      );
}
