using System.ComponentModel.DataAnnotations.Schema;

namespace WatchWise.Models.CrossTables
{
    public class UserFavorite
    {
        public long UserId { get; set; }

        public int MediaId { get; set; }

        [ForeignKey("UserId")]
        public WatchWiseUser? WatchWiseUser { get; set; }

        [ForeignKey("MediaId")]
        public Media? Media { get; set; }
    }
}

