namespace WatchWise.DTOs.Responses
{
	public class GenreResponse
	{
        public short Id { get; set; }
        public string Name { get; set; } = null!;
        public List<int>? MediaIds { get; set; }
    }
}

