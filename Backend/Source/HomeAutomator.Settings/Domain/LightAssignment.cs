using System.Collections.Generic;

namespace HomeAutomator.Settings.Domain
{
    public class LightAssignment
    {
        public LightAssignment(
            string tagId,
            string deviceId,
            IReadOnlyList<LightSettings> lights)
        {
            this.TagId = tagId;
            this.DeviceId = deviceId;
            this.Lights = lights;
        }

        public string TagId { get; }
        
        public string DeviceId { get; }

        public IReadOnlyList<LightSettings> Lights { get; }
    }
}