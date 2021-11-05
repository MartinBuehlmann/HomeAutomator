import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:home_automator/app_state/auth/auth_provider.dart';
import 'package:home_automator/app_state/nfc/nfc_provider.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/constants.dart';
import 'package:home_automator/home_automator_app.dart';
import 'package:provider/provider.dart';

import 'app_state/drawer/drawer_provider.dart';

class App extends StatelessWidget {
  factory App() {
    final urlProvider = UrlProvider();
    final nfcProvider = NfcProvider();
    final authProvider = AuthProvider(urlProvider, nfcProvider);
    return App._(authProvider, urlProvider, nfcProvider);
  }

  const App._(
    this.authProvider,
    this.urlProvider,
    this.nfcProvider,
  );

  final AuthProvider authProvider;
  final UrlProvider urlProvider;
  final NfcProvider nfcProvider;

  @override
  Widget build(BuildContext context) => MultiProvider(
        providers: [
          ChangeNotifierProvider<AuthProvider>(
            create: (_) => authProvider,
          ),
          Provider<UrlProvider>(
            create: (_) => urlProvider,
          ),
          ChangeNotifierProvider<NfcProvider>(
            create: (_) => nfcProvider,
          ),
          ChangeNotifierProvider<DrawerProvider>(
            create: (_) => DrawerProvider(),
          ),
        ],
        builder: (_, __) {
          return MaterialApp(
            title: 'HomeAutomator',
            theme: ThemeData.dark().copyWith(
              scaffoldBackgroundColor: bgColor,
              textTheme:
                  GoogleFonts.poppinsTextTheme(Theme.of(context).textTheme)
                      .apply(bodyColor: Colors.white),
              canvasColor: secondaryColor,
            ),
            home: const HomeAutomatorApp(),
          );
        },
      );
}
