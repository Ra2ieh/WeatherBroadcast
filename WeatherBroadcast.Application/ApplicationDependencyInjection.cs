namespace WeatherBroadcast.Application;

    public static class ApplicationDependencyInjection
    {

            public static  void InstallServices(IServiceCollection services, IConfiguration appSettings)
            {

                services.AddScoped<IWeatherService, WeatherService>();

            }
        
    }

