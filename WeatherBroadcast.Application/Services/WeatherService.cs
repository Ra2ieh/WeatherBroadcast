
using System;
using System.Threading;
using static System.Threading.Tasks.Task;

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

    public async Task<GetWeatherDetailResponse> GetWeatherDetail(CancellationToken cancellationToken)
    {
        var result = new GetWeatherDetailResponse();
        var apiCallTask = GetDataFromApi(cancellationToken);
        var dataBaseTask = GetDataFromDataBase(cancellationToken);
        var delayTask = Delay(TimeSpan.FromSeconds(3), cancellationToken);
        var completedTask = await WhenAny(apiCallTask, dataBaseTask, delayTask);
        if (completedTask == delayTask)
            return null;
        if (completedTask.IsFaulted && completedTask == apiCallTask)
            return await dataBaseTask;
        result = await (Task<GetWeatherDetailResponse>)completedTask;
        if ((completedTask == dataBaseTask && result is null))
        {
            result = await apiCallTask;
            await _unitOfWork.WeatherRepository.AddAsync(ApplicationMapper.Map(result));
        }

        return result;



    }

    private async Task<GetWeatherDetailResponse> GetDataFromDataBase(CancellationToken cancellationToken)
    {
        var weatherData = await _unitOfWork.WeatherRepository.GetAsync(cancellationToken);
        //if (weatherData == null) await Task.Delay(5000, cancellationToken);
        return weatherData != null ? ApplicationMapper.Map(weatherData) : null;
    }

    private async Task<GetWeatherDetailResponse> GetDataFromApi(CancellationToken cancellationToken)
    {


        return await _weatherProvider.GetWeatherDetail(cancellationToken);


    }
}


