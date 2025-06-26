using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Configurations;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess;

public class ShowTimeDbContext : DbContext
{
    public ShowTimeDbContext(DbContextOptions<ShowTimeDbContext> options) : base(options){}
    
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Festival> Festivals { get; set; }
    public DbSet<Lineup> Lineups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShowTimeDbContext).Assembly);

        new ArtistConfiguration().Configure(modelBuilder.Entity<Artist>());;
        new FestivalConfiguration().Configure(modelBuilder.Entity<Festival>());
        new LineupConfiguration().Configure(modelBuilder.Entity<Lineup>());
        new UserConfiguration().Configure(modelBuilder.Entity<User>());
        new BookingConfiguration().Configure(modelBuilder.Entity<Booking>());
    }
}