using WeatherBroadcast.Infrastructure.Repositories;

namespace WeatherBroadcast.Infrastructure.SeedOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly Lazy<IWeatherRepository> _weatherRepository;

    public UnitOfWork(WeatherBroadcastDbContext context)
    {
        _weatherRepository = new Lazy<IWeatherRepository>(() => new WeatherRepository(context));
    }

    public IWeatherRepository WeatherRepository => _weatherRepository.Value;
}