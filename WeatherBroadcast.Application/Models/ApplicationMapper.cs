using WeatherBroadcast.Domain.Entities;
using WeatherBroadcast.Infrastructure.Providers.Models;

namespace WeatherBroadcast.Application.Models;

public static class ApplicationMapper
{

    public static WeatherData Map(GetWeatherDetailResponse weatherDetailResponse)
    {
        return new WeatherData
        {
            Latitude = weatherDetailResponse.Latitude,
            Longitude = weatherDetailResponse.Longitude,
            GenerationtimeMs = weatherDetailResponse.GenerationTimeMs,
            UtcOffsetSeconds = weatherDetailResponse.UtcOffsetSeconds,
            Timezone = weatherDetailResponse.Timezone,
            TimezoneAbbreviation = weatherDetailResponse.TimezoneAbbreviation,
            Elevation = weatherDetailResponse.Elevation,
            HourlyUnits = Map(weatherDetailResponse.HourlyUnits),
            Hourly = Map(weatherDetailResponse.Hourly)
        };
    }

    private static HourlyUnit Map(HourlyUnits weatherDetailResponse)
    {
        return new HourlyUnit
        {
            Time = weatherDetailResponse.Time,
            Temperature2m = weatherDetailResponse.Temperature2M
        };
    }

    private static List<HourlyData> Map(Hourly hourly)
    {
        return hourly.Time.Select((t, i) => new HourlyData { Time = DateTime.Parse(t), Temperature2m = hourly.Temperature2M[i] }).ToList();
    }

    public static GetWeatherDetailResponse Map(WeatherData weatherData)
    {
        return new GetWeatherDetailResponse
        {
            Latitude = weatherData.Latitude,
            Longitude = weatherData.Longitude,
            GenerationTimeMs = weatherData.GenerationtimeMs,
            UtcOffsetSeconds = weatherData.UtcOffsetSeconds,
            Timezone = weatherData.Timezone,
            TimezoneAbbreviation = weatherData.TimezoneAbbreviation,
            Elevation = weatherData.Elevation,
            HourlyUnits = Map(weatherData.HourlyUnits),
            Hourly = Map(weatherData.Hourly)
        };
    }

    public static Hourly Map(List<HourlyData> hourlyData)
    {
        return new Hourly
        {
            Time = hourlyData.Select(h => h.Time.ToString("yyyy-MM-ddTHH:mm")).ToList(),
            Temperature2M = hourlyData.Select(h => h.Temperature2m).ToList()
        };
    }

    public static HourlyUnits Map(HourlyUnit hourlyUnit)
    {
        return new HourlyUnits
        {
            Time = hourlyUnit.Time,
            Temperature2M = hourlyUnit.Temperature2m
        };
    }
}

