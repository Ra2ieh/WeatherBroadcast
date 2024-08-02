
namespace WeatherBroadcast.Domain.Entities;

public class WeatherData
{
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double GenerationtimeMs { get; set; }
    public int UtcOffsetSeconds { get; set; }
    public string Timezone { get; set; }
    public string TimezoneAbbreviation { get; set; }
    public double Elevation { get; set; }
    public HourlyUnit HourlyUnits { get; set; }
    public List<HourlyData> Hourly { get; set; }
}
