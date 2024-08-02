

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
        await _context.WeatherData.AddAsync(weatherData);
        await _context.SaveChangesAsync();
    }

    public async  Task<WeatherData> GetAsync(CancellationToken cancellationToken)
    {
        return await _context.WeatherData
            .OrderBy(e => e.Id).LastOrDefaultAsync(cancellationToken: cancellationToken);
    }


}