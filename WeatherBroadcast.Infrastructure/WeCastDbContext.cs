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


}
