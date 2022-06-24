namespace HomeAutomator.Api.Home
{
    public class ApiHomeInfo
    {
        public ApiHomeInfo(Url automator, Url devices, Url nfcTags, Url settings, Url lights)
        {
            this.Automator = automator;
            this.Devices = devices;
            this.NfcTags = nfcTags;
            this.Settings = settings;
            this.Lights = lights;
        }

        public Url Automator { get; }

        public Url Devices { get; }

        public Url NfcTags { get; }

        public Url Settings { get; }

        public Url Lights { get; }
    }
}