import 'package:flutter/material.dart';

class BusyIndicatorWidget extends StatelessWidget {
  const BusyIndicatorWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) => Stack(
        children: const [
          Opacity(
            opacity: 0.3,
            child: ModalBarrier(dismissible: false, color: Colors.black54),
          ),
          Center(
            child: CircularProgressIndicator(),
          ),
        ],
      );
}
