
using WeatherBroadcast.Infrastructure.Providers.Models;

namespace WeatherBroadcast.Application.Services;

public interface IWeatherService
{
    Task<GetWeatherDetailResponse> GetWeatherDetail();
}
