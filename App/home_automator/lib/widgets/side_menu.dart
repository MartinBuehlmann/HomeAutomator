import 'package:flutter/material.dart';
import 'package:flutter_gen/gen_l10n/app_localizations.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:home_automator/app_state/auth/auth_provider.dart';
import 'package:home_automator/app_state/drawer/drawer_provider.dart';
import 'package:home_automator/routes.dart';
import 'package:home_automator/widgets/app_name_widget.dart';
import 'package:provider/provider.dart';

class SideMenu extends StatelessWidget {
  const SideMenu({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final localizations = AppLocalizations.of(context)!;
    return Consumer<AuthProvider>(
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
                    width: 100,
                    height: 50,
                    child: SvgPicture.asset('assets/images/logo.svg'),
                  ),
                  const AppNameWidget(16),
                ],
              ),
            ),
            DrawerListTile(
                title: localizations.menuItemOverview,
                svgSrc: 'assets/icons/menu_dashboard.svg',
                press: () {
                  Provider.of<DrawerProvider>(
                    context,
                    listen: false,
                  ).setCurrentDrawer(0);
                  Navigator.of(context).pushReplacementNamed(Routes.dashboard);
                }),
            DrawerListTile(
                title: localizations.menuItemNfcTags,
                svgSrc: 'assets/icons/menu_nfc.svg',
                press: () {
                  Provider.of<DrawerProvider>(
                    context,
                    listen: false,
                  ).setCurrentDrawer(0);
                  Navigator.of(context).pushReplacementNamed(Routes.nfcTags);
                }),
            DrawerListTile(
                title: localizations.menuItemSetup,
                svgSrc: 'assets/icons/menu_setting.svg',
                press: () {
                  Provider.of<DrawerProvider>(
                    context,
                    listen: false,
                  ).setCurrentDrawer(0);
                  Navigator.of(context).pushReplacementNamed(Routes.settings);
                }),
            DrawerListTile(
              title: localizations.menuItemLogout,
              svgSrc: 'assets/icons/menu_profile.svg',
              press: () {
                auth.signOut().then((value) =>
                    Navigator.of(context).pushReplacementNamed(Routes.home));
              },
            ),
          ],
        ),
      ),
    );
  }
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
      leading: Container(
          padding: const EdgeInsets.all(4),
          child: SvgPicture.asset(
            svgSrc,
            color: Colors.white70,
            height: 16,
          )),
      title: Text(
        title,
        style: const TextStyle(color: Colors.white70, fontSize: 16),
      ),
    );
  }
}
