import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class AppNameWidget extends StatelessWidget {
  const AppNameWidget(double? fontSize, {Key? key})
      : _fontSize = fontSize,
        super(key: key);

  final double? _fontSize;

  @override
  Widget build(BuildContext context) => RichText(
        textAlign: TextAlign.center,
        text: TextSpan(children: [
          TextSpan(
            text: 'Home',
            style: TextStyle(color: Colors.white, fontSize: _fontSize),
          ),
          TextSpan(
            text: 'Automator',
            style:
                TextStyle(color: const Color(0xffe46b10), fontSize: _fontSize),
          ),
        ]),
      );
}
