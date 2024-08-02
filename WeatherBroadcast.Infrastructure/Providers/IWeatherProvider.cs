namespace WeatherBroadcast.Infrastructure.Providers;

public interface IWeatherProvider
{
    Task<string> GetWeatherDetail(CancellationToken cancellationToken);

}