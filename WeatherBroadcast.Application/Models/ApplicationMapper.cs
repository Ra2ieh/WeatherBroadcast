using WeatherBroadcast.Domain.Entities;
using WeatherBroadcast.Infrastructure.Providers.Models;

namespace WeatherBroadcast.Application.Models;

public static class ApplicationMapper
{

    public static WeatherData Map(string weatherDetailResponse)
    {
        return new WeatherData
        {
            JsonContent = weatherDetailResponse
        };
    }

}

