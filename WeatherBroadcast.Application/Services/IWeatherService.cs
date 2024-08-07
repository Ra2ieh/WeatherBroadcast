namespace WeatherBroadcast.Application.Services;

public interface IWeatherService
{
    Task<GetWeatherDetailResponse> GetWeatherDetail(CancellationToken cancellationToken);
}
