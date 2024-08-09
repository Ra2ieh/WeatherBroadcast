

namespace WeatherBroadcast.Application.Models;

public static class ApplicationMapper
{

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

