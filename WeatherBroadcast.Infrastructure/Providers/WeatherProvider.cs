
using System.Threading;
using WeatherBroadcast.Infrastructure.Providers.Models;

namespace WeatherBroadcast.Infrastructure.Providers;

public class WeatherProvider : IWeatherProvider
{
    public async Task<GetWeatherDetailResponse> GetWeatherDetail(CancellationToken cancellationToken)
    {
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(5);
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.open-meteo.com/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m&relativehumidity_2");
        var response = await client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        var res= await response.Content.ReadAsStringAsync(cancellationToken);
        return JsonConvert.DeserializeObject<GetWeatherDetailResponse>(await response.Content.ReadAsStringAsync(cancellationToken));

    }
}

