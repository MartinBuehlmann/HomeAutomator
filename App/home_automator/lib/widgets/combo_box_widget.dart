import 'package:flutter/material.dart';
import 'package:home_automator/widgets/label_widget.dart';

class ComboBoxWidget extends StatefulWidget {
  const ComboBoxWidget({
    Key? key,
    this.isFocussed = false,
    this.isEnabled = true,
    required this.title,
    required this.items,
    this.value,
    this.onChanged,
  }) : super(key: key);

  final List<DropdownItem> items;
  final bool isFocussed;
  final bool isEnabled;
  final String title;
  final DropdownItem? value;
  final ValueChanged<DropdownItem?>? onChanged;

  @override
  State<ComboBoxWidget> createState() => _ComboBoxWidgetState();
}

class _ComboBoxWidgetState extends State<ComboBoxWidget> {
  _ComboBoxWidgetState();

  DropdownItem? value;
  List<DropdownMenuItem<DropdownItem>> dropdownItems = [];

  @override
  void initState() {
    super.initState();

    value = widget.value;

    dropdownItems.addAll(widget.items.map(
      (DropdownItem item) => DropdownMenuItem<DropdownItem>(
        value: item,
        child: Text(item.displayValue),
      ),
    ));
  }

  @override
  void didUpdateWidget(ComboBoxWidget oldWidget) {
    if (value != widget.value) {
      setState(() {
        value = widget.value;
      });

      super.didUpdateWidget(oldWidget);
    }
  }

  @override
  Widget build(BuildContext context) => Container(
        margin: const EdgeInsets.symmetric(vertical: 10),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: <Widget>[
            LabelWidget(
              text: widget.title,
            ),
            const SizedBox(
              height: 10,
            ),
            Container(
              color: widget.isEnabled ? Colors.white : Colors.white54,
              padding: const EdgeInsets.all(7),
              child: DropdownButtonHideUnderline(
                child: DropdownButton<DropdownItem>(
                  autofocus: widget.isFocussed,
                  items: dropdownItems,
                  value: value,
                  onChanged: (DropdownItem? newValue) => setState(() {
                    value = newValue;
                    widget.onChanged?.call(newValue);
                  }),
                  style: const TextStyle(color: Colors.black),
                  dropdownColor: Colors.white,
                  iconEnabledColor: Colors.black,
                  iconDisabledColor: Colors.black45,
                  isDense: true,
                  isExpanded: true,
                ),
              ),
            ),
          ],
        ),
      );
}

class DropdownItem {
  DropdownItem(this._displayValue, this._value);

  final String _displayValue;
  final String _value;

  String get displayValue => _displayValue;
  String get value => _value;

  @override
  bool operator ==(covariant DropdownItem other) => other.value == value;

  @override
  int get hashCode => value.hashCode;
}
