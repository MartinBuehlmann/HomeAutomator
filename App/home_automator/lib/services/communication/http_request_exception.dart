class HttpRequestException implements Exception {
  HttpRequestException(this.statusCode, this.message, this.requestUrl);

  final int statusCode;
  final String message;
  final Uri requestUrl;

  @override
  String toString() => '$message (Code: $statusCode, Url: $requestUrl)';
}
