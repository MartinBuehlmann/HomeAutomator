namespace HomeAutomator.Api.Lights
{
    public class LightInfo
    {
        public LightInfo(
            string id,
            string name,
            bool isOn,
            string color,
            int brightness,
            bool isReachable,
            string roomName,
            Url self)
        {
            this.Id = id;
            this.Name = name;
            this.IsOn = isOn;
            this.Color = color;
            this.Brightness = brightness;
            this.IsReachable = isReachable;
            this.RoomName = roomName;
            this.Self = self;
        }

        public string Id { get; }

        public string Name { get; }

        public bool IsOn { get; }

        /// <summary>
        ///     Gets the Color in RGB using hex values (i.e. A0EBFF).
        /// </summary>
        public string Color { get; }

        /// <summary>
        ///     Gets the Brightness in percents (0: dark, 100: bright).
        /// </summary>
        public int Brightness { get; }

        public bool IsReachable { get; }

        public string RoomName { get; }

        public Url Self { get; }
    }
}