namespace HomeAutomator.Api.Home
{
    public class ApiHomeInfo
    {
        public ApiHomeInfo(Url devices, Url nfcTags, Url settings, Url lights)
        {
            Devices = devices;
            NfcTags = nfcTags;
            Settings = settings;
            Lights = lights;
        }

        public Url Devices { get; }

        public Url NfcTags { get; }
        
        public Url Settings { get; }
        
        public Url Lights { get; }
    }
}