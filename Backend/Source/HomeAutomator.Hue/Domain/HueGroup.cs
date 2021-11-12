using System.Collections.Generic;

namespace HomeAutomator.Hue.Domain
{
    public class HueGroup
    {
        public HueGroup(string id, string name, IReadOnlyList<HueLight> lights)
        {
            this.Id = id;
            this.Name = name;
            this.Lights = lights;
        }

        public string Id { get; }

        public string Name { get; }

        public IReadOnlyList<HueLight> Lights { get; }
    }
}