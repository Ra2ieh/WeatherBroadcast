

namespace WeatherBroadcast.Infrastructure.Repositories;

public class WeatherRepository : IWeatherRepository
{
    private readonly WeatherBroadcastDbContext _context;
    public WeatherRepository(WeatherBroadcastDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(WeatherData weatherData)
    {
        _context.WeatherData.Add(weatherData);
        await _context.SaveChangesAsync();
    }

    public WeatherData Get()
    {
        return _context.WeatherData
            .OrderBy(e => e.Id).LastOrDefault();
    }

}