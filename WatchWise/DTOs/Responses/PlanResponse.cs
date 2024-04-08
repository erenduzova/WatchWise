namespace WatchWise.DTOs.Responses
{
    public class PlanResponse
    {
        public short Id { get; set; }
        public string Name { get; set; } = null!;
        public float Price { get; set; }
        public string MaxResolution { get; set; } = null!;
    }
}

