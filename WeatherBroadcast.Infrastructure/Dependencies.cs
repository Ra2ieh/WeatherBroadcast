namespace WeatherBroadcast.Infrastructure;

public static class Dependencies
{
 public static void InstallServices(IServiceCollection services, IConfiguration appSettings)
    {
        var optionBuilder=new DbContextOptionsBuilder();
        optionBuilder.LogTo(Console.WriteLine);
        services.AddHttpClient("weatherService", client =>
        {
            var baseUrl = "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m&relativehumidity_2";
            client.BaseAddress = new Uri(baseUrl);
            client.Timeout = TimeSpan.FromSeconds(5);
        }
        );
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IWeatherProvider, WeatherProvider>();
        services.AddDbContext<WeatherBroadcastDbContext>(options =>
        options.UseSqlServer(appSettings.GetConnectionString("WeatherBroadcastDbConnectionString"))
        );
        
        appSettings.GetSection("AppConfig").Get<AppConfig>();
    }
}
