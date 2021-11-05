namespace HomeAutomator.Api.NfcTags
{
    public class NfcTagInfo
    {
        public NfcTagInfo(string tagId, string tagName)
        {
            this.TagId = tagId;
            this.TagName = tagName;
        }

        public string TagId { get; }

        public string TagName { get; }
    }
}