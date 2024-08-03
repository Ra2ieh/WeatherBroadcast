
using System;
using System.Threading;

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

        using var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        try
        {

            var apiCallTask = GetDataFromApi(cancellationToken.Token);
            var dataBaseTask = GetDataFromDataBase(cancellationToken.Token);
            var delayTask = Task.Delay(TimeSpan.FromSeconds(3),cancellationToken.Token);
            var completedTask = await Task.WhenAny(apiCallTask, dataBaseTask, delayTask);
            if (completedTask == delayTask)
                return null;
            if (completedTask == apiCallTask)
                await _unitOfWork.WeatherRepository.AddAsync(ApplicationMapper.Map(apiCallTask.Result));

            return await (Task<GetWeatherDetailResponse>)completedTask;
        }
        catch (Exception e)
        {
            return null;
        }



    }

    private async Task<GetWeatherDetailResponse> GetDataFromDataBase(CancellationToken cancellationToken)
    {
        var weatherData = await _unitOfWork.WeatherRepository.GetAsync(cancellationToken);
        if (weatherData == null) await Task.Delay(5000, cancellationToken);
        return weatherData != null ? ApplicationMapper.Map(weatherData) : null;
    }

    private async Task<GetWeatherDetailResponse> GetDataFromApi(CancellationToken cancellationToken)
    {
        return await _weatherProvider.GetWeatherDetail(cancellationToken);

    }
}


