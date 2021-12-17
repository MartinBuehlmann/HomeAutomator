namespace HomeAutomator.Web.Shared.Configuration;

public class HueBridgeModel
{
    public HueBridgeModel(string id, string displayName)
    {
        this.Id = id;
        this.DisplayName = displayName;
    }

    public string Id { get; }

    public string DisplayName { get; }
}