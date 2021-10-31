import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:home_automator/app_state/auth/auth_provider.dart';
import 'package:home_automator/constants.dart';
import 'package:home_automator/home_automator_app.dart';
import 'package:provider/provider.dart';

class App extends StatelessWidget {
  factory App() {
    final authProvider = AuthProvider();
    return App._(authProvider);
  }

  const App._(this.authProvider);

  final AuthProvider authProvider;

  @override
  Widget build(BuildContext context) => MultiProvider(
          providers: [
            ChangeNotifierProvider<AuthProvider>(
              create: (_) => authProvider,
            ),
          ],
          builder: (_, __) {
            return MaterialApp(
              title: 'Flutter Demo',
              theme: ThemeData.dark().copyWith(
                scaffoldBackgroundColor: bgColor,
                textTheme:
                    GoogleFonts.poppinsTextTheme(Theme.of(context).textTheme)
                        .apply(bodyColor: Colors.white),
                canvasColor: secondaryColor,
              ),
              home: const HomeAutomatorApp(),
            );
          });
}
