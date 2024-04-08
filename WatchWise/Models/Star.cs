namespace WatchWise.Models
{
    public class Star : Person
    {
        public virtual List<MediaStar>? MediaStars { get; set; }
    }
}

