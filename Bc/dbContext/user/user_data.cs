using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.dbContext.user
{
    [Table("user_data")]
    public class user_data
    {
        [Required, Key]
        public long id { get; set; }

        [Required]
        public string login { get; set; } = string.Empty;
        [Required]
        public string user_icon { get; set; } = string.Empty;

        [Required]
        public string password { get; set; } = string.Empty;

        [Required]
        public string email { get; set; } = string.Empty;

        [Required]
        public string user_name { get; set; } = string.Empty;

    }
}
