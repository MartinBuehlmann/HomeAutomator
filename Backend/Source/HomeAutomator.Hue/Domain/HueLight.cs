namespace HomeAutomator.Hue.Domain
{
    public class HueLight
    {
        public HueLight(
            string id,
            HueLightState state,
            string type,
            string name,
            string modelId,
            string productId)
        {
            Id = id;
            State = state;
            Type = type;
            Name = name;
            ModelId = modelId;
            ProductId = productId;
        }

        public string Id { get; }

        public HueLightState State { get; }

        public string Type { get; }

        public string Name { get; }

        public string ModelId { get; }

        public string ProductId { get; }
    }
}