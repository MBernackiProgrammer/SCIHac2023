using Hackathon.Helper;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Hackathon.dbContext.chat;
using Hackathon.dbContext.user_files;
using Hackathon.dbContext.user;
using Hackathon.dbContext.classification;

namespace Hackathon.dbContext
{
    public class Data_context : DbContext
    {
        //public Data_context(DbContextOptions<Data_context> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=" + SQLHelper.Server + ";Port=" + SQLHelper.port + ";Database=hackathon;Username=" + SQLHelper.UserID + ";Password=" + SQLHelper.Password + ";sslmode=" + SQLHelper.SSLmode + ";");
        }

        public DbSet<chat_messages> chat_messages { get; set; }
        public DbSet<stick_to_chat> stick_to_chat { get; set; }
        public DbSet<files> files { get; set; }
        public DbSet<match_data> match_data { get; set; }
        public DbSet<user_answer> user_answer { get; set; }
        public DbSet<user_data> user_data { get; set; }
        public DbSet<match_history> match_history { get; set; }
        public DbSet<user_filters> user_filters { get; set; }
        public DbSet<questions> questions { get; set; }
        public DbSet<user_filter_data> user_filter_data { get; set; }
    }

}
