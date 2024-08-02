namespace WeatherBroadcast.Infrastructure.Providers.Models;

public class HourlyUnits
{
    public string Time { get; set; }
    [JsonProperty("temperature_2m")]
    public string Temperature2M { get; set; }
}