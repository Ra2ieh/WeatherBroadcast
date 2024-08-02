using Azure;

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
        try
        {

            var apiCallTask = GetDataFromApi(cancellationToken.Token);
            await _unitOfWork.WeatherRepository.AddAsync(ApplicationMapper.Map(apiCallTask.Result));
            var dataBaseTask = GetDataFromDataBase(cancellationToken.Token);

            var completedTask = await Task.WhenAny(apiCallTask, dataBaseTask);

            return await completedTask;
        }
        catch (Exception e)
        {
            return null;
        }



    }

    private async Task<GetWeatherDetailResponse> GetDataFromDataBase(CancellationToken cancellationToken)
    {
        var weatherData = await _unitOfWork.WeatherRepository.GetAsync(cancellationToken);
        return weatherData != null ? ApplicationMapper.Map(weatherData) : null;
    }

    private async Task<GetWeatherDetailResponse> GetDataFromApi(CancellationToken cancellationToken)
    {
        
       return await _weatherProvider.GetWeatherDetail(cancellationToken);

    }
}


