using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.dbContext.user
{
    [Table("match_data")]
    public class match_data
    {
        [Required, Key]
        public long id { get; set; }

        [Required]
        public long usr1 { get; set; }

        [Required]
        public long usr2 { get; set; }

        [Required]
        public bool accepted { get; set; }

        [Required]
        public DateTime sent_at { get; set; }
    }
}
