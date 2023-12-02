using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.dbContext.chat
{

    [Table("chat_messages")]
    public class chat_messages
    {
        [Required, Key]
        public long id { get; set; }

        [Required]
        public long answer_to_id { get; set; }

        [Required]
        public long to_chat_id { get; set; }


        [Required]
        public long by_id { get; set; }

        [Required]
        public string value { get; set; } = string.Empty;

    }
}
