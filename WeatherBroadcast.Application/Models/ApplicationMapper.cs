

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

    private static HourlyData Map(Hourly hourly)
    {
        return  new HourlyData { Time = hourly.Time
            , Temperature2M = hourly.Temperature2M };
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

    public static Hourly Map(HourlyData hourlyData)
    {
        return new Hourly
        {
            Time = hourlyData.Time,
            Temperature2M = hourlyData.Temperature2M
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

