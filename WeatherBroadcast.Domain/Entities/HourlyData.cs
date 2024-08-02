

namespace WeatherBroadcast.Domain.Entities
{
    public class HourlyData
    {
        public List<string> Time { get; set; }
        public List<double> Temperature2M { get; set; }
    }
}
