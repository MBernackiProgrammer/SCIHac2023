using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.dbContext.user_files
{
    [Table("files")]
    public class files
    {
        [Key, Required]
        public long file_id { get; set; }

        [Required]
        public long stick_to_user { get; set; }

        [Required]
        public string url { get; set; }
    }
}
