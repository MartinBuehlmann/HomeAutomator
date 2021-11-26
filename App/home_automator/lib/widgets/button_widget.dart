import 'package:flutter/material.dart';
import 'package:home_automator/widgets/label_widget.dart';

class ButtonWidget extends StatelessWidget {
  const ButtonWidget({
    Key? key,
    required this.onPressed,
    required this.text,
    this.isEnabled = true,
  }) : super(key: key);

  final GestureTapCallback onPressed;
  final String text;
  final bool isEnabled;

  @override
  Widget build(BuildContext context) => isEnabled
      ? GestureDetector(
          onTap: onPressed,
          child: _button(
            context,
            const LinearGradient(
                begin: Alignment.centerLeft,
                end: Alignment.centerRight,
                colors: [Color(0xfffbb448), Color(0xfff7892b)]),
          ),
        )
      : _button(
          context,
          const LinearGradient(
              begin: Alignment.centerLeft,
              end: Alignment.centerRight,
              colors: [Color(0xff999aa1), Color(0xff36373a)]),
        );

  Widget _button(BuildContext context, Gradient background) => Container(
        width: MediaQuery.of(context).size.width,
        padding: const EdgeInsets.symmetric(vertical: 10),
        alignment: Alignment.center,
        decoration: BoxDecoration(
            borderRadius: const BorderRadius.all(Radius.circular(5)),
            boxShadow: const <BoxShadow>[
              BoxShadow(
                  color: Colors.black,
                  offset: Offset(2, 4),
                  blurRadius: 5,
                  spreadRadius: 2)
            ],
            gradient: background),
        child: LabelWidget(
          text: text,
        ),
      );
}
