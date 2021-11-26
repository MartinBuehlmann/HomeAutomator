namespace HomeAutomator.Api.Lights
{
    public class LightInfo
    {
        public LightInfo(
            string id, 
            string name,
            bool @on,
            string color,
            int brightness,
            bool isReachable,
            string roomName,
            Url self)
        {
            this.Id = id;
            this.Name = name;
            this.On = @on;
            this.Color = color;
            this.Brightness = brightness;
            this.IsReachable = isReachable;
            this.RoomName = roomName;
            this.Self = self;
        }

        public string Id { get; }

        public string Name { get; }

        public bool On { get; }

        /// <summary>
        /// Color in RGB using hex values (i.e. A0EBFF)
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Brightness in percents (0: dark, 100: bright)
        /// </summary>
        public int Brightness { get; }

        public bool IsReachable { get; }

        public string RoomName { get; }

        public Url Self { get; }
    }
}