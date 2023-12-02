using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.dbContext.user
{
    [PrimaryKey(nameof(user_id), nameof(match_user_id))]
    [Table("match_history")]
    public class match_history
    {
        [Required]
        public long user_id { get; set; }

        [Required]
        public long match_user_id { get; set;}
    }
}
