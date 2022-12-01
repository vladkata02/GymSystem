using Microsoft.EntityFrameworkCore;

namespace GymSystem.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Price> Prices { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }
    }
}