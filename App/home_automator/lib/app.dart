import 'package:flutter/material.dart';
import 'package:flutter_gen/gen_l10n/app_localizations.dart';
import 'package:flutter_localizations/flutter_localizations.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:home_automator/app_state/auth/auth_provider.dart';
import 'package:home_automator/app_state/nfc/nfc_provider.dart';
import 'package:home_automator/app_state/urls/url_provider.dart';
import 'package:home_automator/constants.dart';
import 'package:home_automator/pages/dashboard/dashboard_page.dart';
import 'package:home_automator/pages/home/home_page.dart';
import 'package:home_automator/pages/main/main_page.dart';
import 'package:home_automator/pages/nfc_tags/nfc_tags_page.dart';
import 'package:home_automator/pages/settings/light_selection/light_selection_page.dart';
import 'package:home_automator/pages/settings/light_settings/light_settings_page.dart';
import 'package:home_automator/pages/settings/settings_page.dart';
import 'package:home_automator/routes.dart';
import 'package:provider/provider.dart';

import 'app_state/drawer/drawer_provider.dart';

class App extends StatelessWidget {
  factory App() {
    final urlProvider = UrlProvider();
    final nfcProvider = NfcProvider(urlProvider);
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
            onGenerateTitle: (BuildContext context) =>
                AppLocalizations.of(context)!.appTitle,
            theme: ThemeData.dark().copyWith(
              scaffoldBackgroundColor: bgColor,
              textTheme:
                  GoogleFonts.poppinsTextTheme(Theme.of(context).textTheme)
                      .apply(bodyColor: Colors.white),
              canvasColor: secondaryColor,
            ),
            localizationsDelegates: const [
              AppLocalizations.delegate,
              GlobalMaterialLocalizations.delegate,
              GlobalWidgetsLocalizations.delegate,
              GlobalCupertinoLocalizations.delegate,
            ],
            supportedLocales: const [
              Locale('de', ''),
            ],
            initialRoute: Routes.home,
            routes: {
              Routes.home: (context) => const MainPage(),
              Routes.dashboard: (context) => HomePage(
                    content: const DashboardPage(),
                    title: AppLocalizations.of(context)!.pageHeaderOverview,
                  ),
              Routes.nfcTags: (context) => HomePage(
                    content: const NfcTagsPage(),
                    title: AppLocalizations.of(context)!.pageHeaderNfcTags,
                  ),
              Routes.settings: (context) => HomePage(
                    content: const SettingsPage(),
                    title: AppLocalizations.of(context)!.pageHeaderSetup,
                  ),
              Routes.lightSelection: (context) => HomePage(
                    content: const LightSelectionPage(),
                    title: AppLocalizations.of(context)!.pageHeaderSelectLight,
                  ),
              Routes.lightSettings: (context) => HomePage(
                    content: const LightSettingsPage(),
                    title: AppLocalizations.of(context)!.pageHeaderSetupLight,
                  ),
            },
          );
        },
      );
}
