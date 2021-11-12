class NfcTagData {
  NfcTagData(this._tagId, this._tagName);
  final String _tagId;
  final String _tagName;

  String get tagId => _tagId;

  String get tagName => _tagName;
}
