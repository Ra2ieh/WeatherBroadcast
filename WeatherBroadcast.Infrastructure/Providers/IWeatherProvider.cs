using WeatherBroadcast.Infrastructure.Providers.Models;

namespace WeatherBroadcast.Infrastructure.Providers;

public interface IWeatherProvider
{
    Task<GetWeatherDetailResponse> GetWeatherDetail(CancellationToken cancellationToken);

}