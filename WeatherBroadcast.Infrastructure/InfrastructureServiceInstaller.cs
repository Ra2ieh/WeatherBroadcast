namespace WeatherBroadcast.Infrastructure;

public static class InfrastructureServiceInstaller
{
 public static void InstallServices(IServiceCollection services, IConfiguration appSettings)
    {
        var optionBuilder=new DbContextOptionsBuilder();
        optionBuilder.LogTo(Console.WriteLine);
        services.AddHttpClient("deliveryTimeService", client =>
        {
            var baseUrl = appSettings.GetSection("AppConfig:GetDeliveryTimeConfig:BaseUrl").Value;
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
