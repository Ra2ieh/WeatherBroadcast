using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WeatherBroadcast.Infrastructure;

public class WeatherBroadcastDbContext : DbContext
{
    #region constructor
    public WeatherBroadcastDbContext(DbContextOptions<WeatherBroadcastDbContext> options) : base(options)
    {

    }

    #endregion
    public DbSet<WeatherData> WeatherData { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var hourlyDataConverter = new ValueConverter<HourlyData, string>(
            v => JsonSerializer.Serialize(v, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
            v => JsonSerializer.Deserialize<HourlyData>(v, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }));

        modelBuilder.Entity<WeatherData>()
            .Property(e => e.Hourly)
            .HasConversion(hourlyDataConverter);

        var hourlyUnitsConverter = new ValueConverter<HourlyUnit, string>(
            v => JsonSerializer.Serialize(v, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }),
            v => JsonSerializer.Deserialize<HourlyUnit>(v, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }));

        modelBuilder.Entity<WeatherData>()
            .Property(e => e.HourlyUnits)
            .HasConversion(hourlyUnitsConverter);
    }

}
