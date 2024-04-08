namespace WatchWise.DTOs.Responses
{
    public class MediaResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public float ImdbRating { get; set; }
        public bool Passive { get; set; }
        public List<short>? GenreIds { get; set; }
        public List<int>? StarIds { get; set; }
        public List<int>? DirectorIds { get; set; }
        public List<byte>? RestrictionIds { get; set; }
    }
}

