import 'dart:convert';
import 'package:http/http.dart' as http;

import 'http_request_exception.dart';

class HttpClientWrapper {
  static Future put(String url, Object data) async {
    final response = await http.put(
      Uri.parse(url),
      body: jsonEncode(data),
      headers: _getHeaders(),
    );

    _verifyResponse(response);
  }

  static Future<dynamic> get(String url) async {
    final response = await http.get(
      Uri.parse(url),
      headers: _getHeaders(),
    );

    _verifyResponse(response);

    return jsonDecode(response.body);
  }

  static Future head(String url) async {
    final response = await http.head(
      Uri.parse(url),
      headers: _getHeaders(),
    );

    _verifyResponse(response);
  }

  static Map<String, String> _getHeaders() => <String, String>{
        'Content-Type': 'application/json',
      };

  static void _verifyResponse(http.Response response) {
    if (response.statusCode < 200 || 299 < response.statusCode) {
      throw HttpRequestException(response.statusCode,
          'Request was not successful', response.request!.url);
    }
  }
}
