using System;
namespace WatchWise.Models
{
	public class Director : Person
	{
        public List<MediaDirector>? MediaDirectors { get; set; }
    }
}

