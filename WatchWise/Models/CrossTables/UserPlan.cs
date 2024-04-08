using System.ComponentModel.DataAnnotations.Schema;

namespace WatchWise.Models.CrossTables
{
    public class UserPlan
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public WatchWiseUser? WatchWiseUser { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public short PlanId { get; set; }
        [ForeignKey("PlanId")]
        public Plan? Plan { get; set; }

    }
}

