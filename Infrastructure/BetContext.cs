using Microsoft.EntityFrameworkCore;
using Web1xbet.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Web1xbet.Infrastructure
{
    public class BetContext : DbContext
    {
        public DbSet<Bet> Bets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; }

        public BetContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(user => user.FIO);
            modelBuilder.Entity<User>().HasAlternateKey(user => user.Username);

            modelBuilder.Entity<User>().HasOne<StatusType>(u => u.Status);
            modelBuilder.Entity<Event>().HasOne<EventType>(e => e.Type);
            modelBuilder.Entity<Bet>().HasOne<User>(b => b.User);
            modelBuilder.Entity<Bet>().HasOne<Event>(b => b.Event);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
        }
    }
}
