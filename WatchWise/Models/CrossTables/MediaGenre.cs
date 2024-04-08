using System.ComponentModel.DataAnnotations.Schema;

namespace WatchWise.Models
{
    public class MediaGenre
    {

        public int MediaId { get; set; }

        public short GenreId { get; set; }

        [ForeignKey("MediaId")]
        public Media? Media { get; set; }

        [ForeignKey("GenreId")]
        public Genre? Genre { get; set; }

    }
}

