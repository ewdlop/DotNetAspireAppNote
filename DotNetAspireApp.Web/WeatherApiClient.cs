using System.Runtime.CompilerServices;

namespace DotNetAspireApp.Web;

public class WeatherApiClient(HttpClient httpClient)
{
    public async Task<WeatherForecast[]> GetWeatherAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        return (await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast", cancellationToken: cancellationToken)) ?? [];
    }

    public async IAsyncEnumerable<WeatherForecast[]> GetWeatherStreamDataAsync(int maxItems = 10, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {

        await foreach (var forecasts in httpClient.GetFromJsonAsAsyncEnumerable<WeatherForecast[]>("/api/stream", cancellationToken))
        {
            if (cancellationToken.IsCancellationRequested)
            {
                yield break;
            }
            if (forecasts is not null)
            {
                yield return forecasts;
            }
        }
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
