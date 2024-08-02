namespace WeatherBroadcast.Domain.Entities;

public class HourlyData
{
    public int Id { get; set; }
    public DateTime Time { get; set; }
    public double Temperature2m { get; set; }
    public int WeatherDataId { get; set; } // Foreign key
    public WeatherData WeatherData { get; set; }
}