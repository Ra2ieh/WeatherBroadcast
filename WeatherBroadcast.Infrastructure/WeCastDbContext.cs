using WeatherBroadcast.Domain.Entities;
using Hourly = WeatherBroadcast.Infrastructure.Services.Models.Hourly;
using HourlyUnits = WeatherBroadcast.Infrastructure.Services.Models.HourlyUnits;

namespace WeatherBroadcast.Infrastructure;

public class WeatherBroadcastDbContext : DbContext
{
    #region constructor
    public WeatherBroadcastDbContext(DbContextOptions<WeatherBroadcastDbContext> options) : base(options)
    {

    }

    #endregion
    public DbSet<WeatherData> WeatherData { get; set; }
    public DbSet<HourlyUnit> HourlyUnits { get; set; }
    public DbSet<HourlyData> Hourly { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherData>()
            .OwnsOne(w => w.HourlyUnits);

        modelBuilder.Entity<HourlyData>()
            .HasOne(h => h.WeatherData)
            .WithMany(w => w.Hourly)
            .HasForeignKey(h => h.WeatherDataId);

    }
}
