namespace WeatherBroadcast.Infrastructure.Configs;
public class AppConfig
{
    public AppConfig()
    {
        ErrorMessages = new List<ErrorMessage>();
    }
    public List<ErrorMessage> ErrorMessages { get; set; }
}
