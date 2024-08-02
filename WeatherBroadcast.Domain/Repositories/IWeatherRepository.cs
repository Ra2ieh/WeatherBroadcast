

namespace WeatherBroadcast.Domain.Repositories;

public interface IWeatherRepository
{
    Task AddAsync(WeatherData data);
    WeatherData Get();
}