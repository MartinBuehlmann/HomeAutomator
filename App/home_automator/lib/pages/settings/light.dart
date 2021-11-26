class Light {
  Light(
    this.id,
    this.name,
    this.on,
    this.color,
    this.brightness,
    this.isReachable,
    this.roomName,
    this.self,
  );

  String id;
  String name;
  bool on;
  String color;
  int brightness;
  bool isReachable;
  String roomName;
  String self;
}
