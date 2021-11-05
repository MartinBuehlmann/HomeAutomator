import 'package:flutter/material.dart';
import 'package:home_automator/constants.dart';
import 'package:home_automator/responsive.dart';
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
          child: Row(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              // We want this side menu only for large screen
              if (Responsive.isDesktop(context))
                const Expanded(
                  // default flex = 1
                  // and it takes 1/6 part of the screen
                  child: SideMenu(),
                ),
              Expanded(
                // It takes 5/6 part of the screen
                flex: 5,
                child: content,
              ),
            ],
          ),
        ),
      );
}
