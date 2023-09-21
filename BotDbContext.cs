using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using TelegramBot.Balance;

namespace TelegramBot
{
    internal class BotDbContext : DbContext
    {
        public DbSet<Model> Model { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=AGENTS\DATABASE;Initial Catalog=tgshop_db;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
