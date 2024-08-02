

namespace WeatherBroadcast.Domain.Repositories;

public interface IWeatherRepository
{
    Task AddAsync(WeatherData data);
    Task<WeatherData> GetAsync(CancellationToken cancellationToken);
}