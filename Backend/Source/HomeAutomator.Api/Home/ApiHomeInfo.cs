namespace HomeAutomator.Api.Home
{
    public class ApiHomeInfo
    {
        public ApiHomeInfo(Url devices, Url nfcTags)
        {
            Devices = devices;
            NfcTags = nfcTags;
        }

        public Url Devices { get; }

        public Url NfcTags { get; }
    }
}