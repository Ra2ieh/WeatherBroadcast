
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using static System.Threading.Tasks.Task;

namespace WeatherBroadcast.Application.Services;

public class WeatherService : IWeatherService
{
    private readonly IWeatherProvider _weatherProvider;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDistributedCache _distributedCache;

    public WeatherService(IWeatherProvider weatherProvider, IUnitOfWork unitOfWork, IDistributedCache distributedCache)
    {
        _weatherProvider = weatherProvider;
        _unitOfWork = unitOfWork;
        _distributedCache = distributedCache;
    }

    public async Task<GetWeatherDetailResponse> GetWeatherDetail(CancellationToken cancellationToken)
    {
        const string cacheKey = "WeatherBroadcastResult";
        var cacheResult = await _distributedCache.GetStringAsync(cacheKey, token: cancellationToken);
        if (cacheResult != null) return JsonConvert.DeserializeObject<GetWeatherDetailResponse>(cacheResult);
        var apiCallTask = GetDataFromApi(cancellationToken);
        var dataBaseTask = GetDataFromDataBase(cancellationToken);
        var delayTask = Delay(TimeSpan.FromSeconds(3), cancellationToken);
        var completedTask = await WhenAny(apiCallTask, dataBaseTask, delayTask);
        if (completedTask == delayTask)
            return null;
        if (completedTask.IsFaulted && completedTask == apiCallTask)
            return await dataBaseTask;
        var result = await (Task<GetWeatherDetailResponse>)completedTask;
        if ((completedTask == dataBaseTask && result is null))
        {
            result = await apiCallTask;
            await _unitOfWork.WeatherRepository.AddAsync(ApplicationMapper.Map(result));
        }

        await _distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(result), options: new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
        }, token: cancellationToken);
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


