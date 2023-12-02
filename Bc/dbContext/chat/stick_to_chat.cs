using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.dbContext.chat
{
    [Table("stick_to_chat")]
    public class stick_to_chat
    {
        [Required, Key]
        public long id { get; set; }

        [Required]
        public long stick_to_chat_id { get; set; }

        [Required]
        public long user_id { get; set; }
        [Required]
        public long last_read_message { get; set; }

        [Required]
        public bool blocked { get; set; }
    }
}