using Microsoft.EntityFrameworkCore;
using SQLiteRouletteAPI.Models;

namespace SQLiteRouletteAPI.Data
{
    public class RouletteDbContext : DbContext
    {
        public RouletteDbContext(DbContextOptions<RouletteDbContext> options) : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Payout> Payouts { get; set; }
        public DbSet<SpinResult> SpinResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model here if needed
            modelBuilder.Entity<Bet>().ToTable("Bets").HasKey(b => b.BetId);
            modelBuilder.Entity<Payout>().ToTable("Payouts").HasKey(p => p.PayoutId);
            modelBuilder.Entity<SpinResult>().ToTable("SpinResults").HasKey(s => s.SpinIdNumber); 
        }
    }
}