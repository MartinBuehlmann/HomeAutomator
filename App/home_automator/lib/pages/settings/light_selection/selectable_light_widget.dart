import 'package:flutter/material.dart';
import 'package:home_automator/pages/settings/light_selection/selectable_light.dart';

class SelectableLightWidget extends StatefulWidget {
  const SelectableLightWidget(this.selectableLight, {Key? key})
      : super(key: key);

  final SelectableLight selectableLight;

  @override
  State<SelectableLightWidget> createState() => _SelectableLightWidgetState();
}

class _SelectableLightWidgetState extends State<SelectableLightWidget> {
  @override
  Widget build(BuildContext context) => GestureDetector(
        onTap: () {
          setState(() {
            widget.selectableLight.selected = !widget.selectableLight.selected;
          });
        },
        child: Container(
          margin: const EdgeInsets.fromLTRB(0, 1, 0, 1),
          padding: const EdgeInsets.all(5),
          decoration: BoxDecoration(
            border: Border.all(
              color: Colors.black,
            ),
            color: Colors.white10,
            borderRadius: const BorderRadius.all(
              Radius.circular(5),
            ),
          ),
          child: Row(
            children: [
              Checkbox(
                  value: widget.selectableLight.selected,
                  onChanged: (bool? value) {
                    setState(() {
                      widget.selectableLight.selected = value!;
                    });
                  }),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    widget.selectableLight.light.name,
                    style: const TextStyle(fontSize: 16, color: Colors.white),
                  ),
                  Text(
                    widget.selectableLight.light.roomName,
                    style: const TextStyle(fontSize: 16, color: Colors.white),
                  ),
                ],
              ),
            ],
          ),
        ),
      );
}
