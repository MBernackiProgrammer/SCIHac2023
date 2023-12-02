using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.dbContext.user
{
    [Table("questions")]
    public class questions
    {
        [Required, Key]
        public long id { get; set; }

        [Required]
        public string question { get; set; } = string.Empty;

    }
}
