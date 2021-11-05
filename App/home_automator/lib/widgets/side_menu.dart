import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:home_automator/app_state/auth/auth_provider.dart';
import 'package:home_automator/app_state/drawer/drawer_provider.dart';
import 'package:home_automator/pages/dashboard/dashboard_page.dart';
import 'package:home_automator/pages/home/home_page.dart';
import 'package:home_automator/pages/nfc_tags/nfc_tags_page.dart';
import 'package:home_automator/pages/settings/settings_page.dart';
import 'package:home_automator/widgets/app_name_widget.dart';
import 'package:provider/provider.dart';

class SideMenu extends StatelessWidget {
  const SideMenu({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) => Consumer<AuthProvider>(
        builder: (context, auth, _) => Drawer(
          child: ListView(
            children: [
              DrawerHeader(
                child: Column(
                  children: [
                    const SizedBox(
                      height: 25,
                    ),
                    SizedBox(
                      child: SvgPicture.asset('assets/images/logo.svg'),
                      width: 100,
                      height: 50,
                    ),
                    const AppNameWidget(16),
                  ],
                ),
              ),
              DrawerListTile(
                  title: 'Übersicht',
                  svgSrc: 'assets/icons/menu_dashboard.svg',
                  press: () {
                    Navigator.of(context).pop();
                    Provider.of<DrawerProvider>(
                      context,
                      listen: false,
                    ).setCurrentDrawer(0);
                    Navigator.of(context).pushReplacement(MaterialPageRoute(
                        builder: (BuildContext context) => const HomePage(
                              content: DashboardPage(),
                              title: 'Übersicht',
                            )));
                  }),
              DrawerListTile(
                  title: 'NFC Tags',
                  svgSrc: 'assets/icons/menu_nfc.svg',
                  press: () {
                    Provider.of<DrawerProvider>(
                      context,
                      listen: false,
                    ).setCurrentDrawer(0);
                    Navigator.of(context).pushReplacement(MaterialPageRoute(
                        builder: (BuildContext context) => const HomePage(
                              content: NfcTagsPage(),
                              title: 'NFC Tags',
                            )));
                  }),
              DrawerListTile(
                  title: 'Einstellungen',
                  svgSrc: 'assets/icons/menu_setting.svg',
                  press: () {
                    Provider.of<DrawerProvider>(
                      context,
                      listen: false,
                    ).setCurrentDrawer(0);
                    Navigator.of(context).pushReplacement(MaterialPageRoute(
                        builder: (BuildContext context) => const HomePage(
                              content: SettingsPage(),
                              title: 'Einstellungen',
                            )));
                  }),
              DrawerListTile(
                title: 'Abmelden',
                svgSrc: 'assets/icons/menu_profile.svg',
                press: () {
                  Navigator.of(context).popUntil((route) => route.isFirst);
                  auth.signOut();
                },
              ),
            ],
          ),
        ),
      );
}

class DrawerListTile extends StatelessWidget {
  const DrawerListTile({
    Key? key,
    // For selecting those three line once press 'Command+D'
    required this.title,
    required this.svgSrc,
    required this.press,
  }) : super(key: key);

  final String title, svgSrc;
  final VoidCallback press;

  @override
  Widget build(BuildContext context) {
    return ListTile(
      onTap: press,
      horizontalTitleGap: 0.0,
      leading: SvgPicture.asset(
        svgSrc,
        color: Colors.white54,
        height: 16,
      ),
      title: Text(
        title,
        style: const TextStyle(color: Colors.white54),
      ),
    );
  }
}
