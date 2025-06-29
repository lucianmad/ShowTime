using Microsoft.EntityFrameworkCore;
using ShowTime.DataAccess.Configurations;
using ShowTime.DataAccess.Models;

namespace ShowTime.DataAccess;

public class ShowTimeDbContext : DbContext
{
    public ShowTimeDbContext(DbContextOptions<ShowTimeDbContext> options) : base(options){}
    
    public ShowTimeDbContext(){}
    
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Festival> Festivals { get; set; }
    public DbSet<Lineup> Lineups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ShowTimeDB;User Id=sa;Password=LucianMad123!;TrustServerCertificate=true;");
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShowTimeDbContext).Assembly);
    }
}