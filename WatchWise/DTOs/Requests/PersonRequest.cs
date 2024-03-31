using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WatchWise.DTOs.Requests
{
    public class PersonRequest
    {
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; } = null!;
    }
}
