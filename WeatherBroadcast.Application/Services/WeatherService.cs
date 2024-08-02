namespace WeatherBroadcast.Application.Services;

public class WeatherService : IWeatherService
{
    private readonly IWeatherProvider _weatherProvider;
    private readonly IUnitOfWork _unitOfWork;

    public WeatherService(IWeatherProvider weatherProvider, IUnitOfWork unitOfWork)
    {
        _weatherProvider = weatherProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task<GetWeatherDetailResponse> GetWeatherDetail()
    {

        using var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5));
        GetWeatherDetailResponse weatherDetail;
        try
        {
            var response  = await _weatherProvider.GetWeatherDetail(cancellationToken.Token);
            await _unitOfWork.WeatherRepository.AddAsync(ApplicationMapper.Map(response));
            weatherDetail = JsonConvert.DeserializeObject<GetWeatherDetailResponse>(response);

        }
        catch (Exception)
        {
            weatherDetail=HandleError();
        }
        return weatherDetail;
    }

    private GetWeatherDetailResponse HandleError()
    {
        var weatherData = _unitOfWork.WeatherRepository.Get();
        return weatherData != null ? JsonConvert.DeserializeObject<GetWeatherDetailResponse>(weatherData.JsonContent) : null;
    }
}


