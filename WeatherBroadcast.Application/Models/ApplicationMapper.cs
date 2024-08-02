

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

