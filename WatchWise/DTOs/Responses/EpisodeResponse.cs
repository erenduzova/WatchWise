namespace WatchWise.DTOs.Responses
{
	public class EpisodeResponse
	{
        public long Id { get; set; }
        public int MediaId { get; set; }
        public byte SeasonNum { get; set; }
        public short EpisodeNum { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; } = "";
        public string? Description { get; set; }
        public TimeSpan Duration { get; set; }
        public long ViewCount { get; set; }
        public bool Passive { get; set; }
    }
}

