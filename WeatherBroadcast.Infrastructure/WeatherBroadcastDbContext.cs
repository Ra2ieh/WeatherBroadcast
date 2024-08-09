

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
