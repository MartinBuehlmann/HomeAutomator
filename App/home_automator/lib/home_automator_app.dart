import 'package:flutter/cupertino.dart';
import 'package:home_automator/app_state/auth/auth_provider.dart';
import 'package:home_automator/pages/login_page/log_in_page.dart';
import 'package:home_automator/pages/home/home_page.dart';
import 'package:home_automator/widgets/busy_indicator_widget.dart';
import 'package:provider/provider.dart';

class HomeAutomatorApp extends StatelessWidget {
  const HomeAutomatorApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final authProvider = Provider.of<AuthProvider>(context, listen: false);
    final signInAutomatically = authProvider.signInAutomatically();
    const loginPage = LogInPage();

    return Consumer<AuthProvider>(
      builder: (_, auth, __) {
        if (auth.isLoggedIn) {
          return const HomePage(title: 'Flutter Demo Home Page');
        }

        return SafeArea(
            child: Stack(
          children: [
            FutureBuilder(
              future: signInAutomatically,
              builder: (context, snapshot) {
                if (snapshot.hasError) {
                  return loginPage;
                }

                return loginPage;
              },
            ),
            if (auth.isLoggingIn) BusyIndicatorWidget(),
          ],
        ));
      },
    );
  }
}
