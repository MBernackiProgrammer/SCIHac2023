using Hackathon.dbContext.classification;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.dbContext.user
{
    [PrimaryKey(nameof(to_question), nameof(user_id))]
    [Table("user_answer")]
    public class user_answer
    {
        [Required]
        public long to_question { get; set; }

        [Required]
        public string value { get; set; } = string.Empty;

        [Required]
        public long user_id { get; set; }
    }
}
