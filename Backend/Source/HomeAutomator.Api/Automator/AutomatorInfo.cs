namespace HomeAutomator.Api.Automator;

public class AutomatorInfo
{
    public AutomatorInfo(string deviceId, string tagId)
    {
        this.DeviceId = deviceId;
        this.TagId = tagId;
    }

    public string DeviceId { get; }

    public string TagId { get; }
}