using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.dbContext.classification
{
    [Table("user_filters")]
    public class user_filters
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
        public int from_age { get; set; }

        [Required]
        public int to_age { get; set; }

    }
}
