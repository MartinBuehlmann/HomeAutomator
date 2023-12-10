namespace HomeAutomator.Api.NfcTags;

public class NfcTagInfo
{
    public NfcTagInfo(
        string tagId,
        string tagName,
        Url self)
    {
        this.TagId = tagId;
        this.TagName = tagName;
        this.Self = self;
    }

    public string TagId { get; }

    public string TagName { get; }

    public Url Self { get; }
}