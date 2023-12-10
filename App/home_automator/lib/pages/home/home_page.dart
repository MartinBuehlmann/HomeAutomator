import 'package:flutter/material.dart';
import 'package:home_automator/constants.dart';
import 'package:home_automator/widgets/side_menu.dart';

class HomePage extends StatelessWidget {
  const HomePage({Key? key, required this.content, required this.title})
      : super(key: key);

  final Widget content;
  final String title;

  @override
  Widget build(BuildContext context) => Scaffold(
        appBar: AppBar(
          title: Text(title),
          backgroundColor: bgColor,
        ),
        drawer: const SideMenu(),
        body: SafeArea(
          child: SingleChildScrollView(
            padding: const EdgeInsets.all(defaultPadding),
            child: content,
          ),
        ),
      );
}
