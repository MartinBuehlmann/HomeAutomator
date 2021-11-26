namespace HomeAutomator.Api.Settings
{
    public class LightSettingsInfo
    {
        public LightSettingsInfo(
            string id, 
            bool @on,
            string color,
            int brightness,
            Url light)
        {
            this.Id = id;
            this.On = @on;
            this.Color = color;
            this.Brightness = brightness;
            this.Light = light;
        }

        public string Id { get; }

        public bool On { get; }

        /// <summary>
        /// Color in RGB using hex values (i.e. A0EBFF)
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Brightness in percents (0: dark, 100: bright)
        /// </summary>
        public int Brightness { get; }

        public Url Light { get; }
    }
}