import 'dart:convert';
import 'package:http/http.dart' as http;

class HttpClientWrapper {
  static Future put(String url, Object data) async => http.put(
        Uri.parse(url),
        body: jsonEncode(data),
        headers: _getHeaders(),
      );

  static Future<dynamic> get(String url) async {
    final response = await http.get(
      Uri.parse(url),
      headers: _getHeaders(),
    );

    return jsonDecode(response.body);
  }

  static Future head(String url) async => http.head(
        Uri.parse(url),
        headers: _getHeaders(),
      );

  static Map<String, String> _getHeaders() => <String, String>{
        'Content-Type': 'application/json',
      };
}
