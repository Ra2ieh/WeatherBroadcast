namespace WeatherBroadcast.Infrastructure.Providers.Models;

public class GetWeatherDetailResponse
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    [JsonProperty("generationtime_ms")]
    public double GenerationTimeMs { get; set; }
    [JsonProperty("utc_offset_seconds")]
    public int UtcOffsetSeconds { get; set; }
    public string Timezone { get; set; }
    [JsonProperty("timezone_abbreviation")]
    public string TimezoneAbbreviation { get; set; }
    public double Elevation { get; set; }
    [JsonProperty("hourly_units")]
    public HourlyUnits HourlyUnits { get; set; }
    public Hourly Hourly { get; set; }
}