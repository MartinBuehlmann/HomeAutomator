namespace HomeAutomator.Web.Shared.Hue.Configuration
{
    public class HueBridgeModel
    {
        public HueBridgeModel(string? id, string displayName)
        {
            Id = id;
            DisplayName = displayName;
        }

        public string? Id { get; }

        public string DisplayName { get; }
    }
}