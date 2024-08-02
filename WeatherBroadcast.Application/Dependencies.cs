namespace WeatherBroadcast.Application;

public static class Dependencies
{

    public static void InstallServices(IServiceCollection services, IConfiguration appSettings)
    {

        services.AddScoped<IWeatherService, WeatherService>();

    }

}

