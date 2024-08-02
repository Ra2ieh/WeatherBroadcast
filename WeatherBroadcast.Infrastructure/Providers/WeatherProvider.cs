using WeatherBroadcast.Infrastructure.Providers.Models;

namespace WeatherBroadcast.Infrastructure.Providers;

public class WeatherProvider : IWeatherProvider
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherProvider(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<GetWeatherDetailResponse> GetWeatherDetail(CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("weatherService");
        var request = new HttpRequestMessage(HttpMethod.Get, "");
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return JsonConvert.DeserializeObject<GetWeatherDetailResponse>(await response.Content.ReadAsStringAsync(cancellationToken)); 

    }
}

