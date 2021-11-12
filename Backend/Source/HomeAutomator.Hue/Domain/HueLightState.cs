namespace HomeAutomator.Hue.Domain
{
    public class HueLightState
    {
        public HueLightState(bool @on, string color, byte brightness, bool? isReachable)
        {
            On = @on;
            Color = color;
            Brightness = brightness;
            IsReachable = isReachable;
        }

        public bool On { get; }

        public string Color { get; set; }
        
        public byte Brightness { get; }

        public bool? IsReachable { get; }
    }
}