namespace WeatherBroadcast.Infrastructure.Providers.Models;

public class Hourly
{
    public List<string> Time { get; set; }
    [JsonProperty("temperature_2m")]
    public List<double> Temperature2M { get; set; }
}