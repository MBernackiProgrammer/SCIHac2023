using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.dbContext.classification
{
    [Table("user_filter_data1")]
    public class user_filter_data
    {
        [Required, Key]
        public long user_id { get; set; }

        [Required]
        public string location { get; set; } = string.Empty;

        [Required]
        public int tv { get; set; }

        [Required]
        public int sex { get; set; }

        [Required]
        public DateOnly date_of_birth { get; set; }

    }
}
