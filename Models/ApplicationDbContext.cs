using Microsoft.EntityFrameworkCore;

namespace ConferenceBarrel.Models
{
    public class ApplicationDbContext : DbContext{
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Session> Session { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlite("Filename=./confbarrel.db");
        }
    }
}