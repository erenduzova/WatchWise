namespace WatchWise.Models
{
    public class Director : Person
    {
        public virtual List<MediaDirector>? MediaDirectors { get; set; }
    }
}

