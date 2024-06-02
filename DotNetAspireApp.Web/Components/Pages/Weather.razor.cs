using Microsoft.AspNetCore.Components;

namespace DotNetAspireApp.Web.Components.Pages;

public partial class Weather : IDisposable
{
    [Inject]
    public  required WeatherApiClient WeatherApi { get; init; }
    //private WeatherForecast[]? _forecasts = [];
    private List<WeatherForecast> _forecasts = [];
    private CancellationTokenSource _cancellationTokenSource = new ();
    //protected override void OnInitialized()
    //{
    //    InvokeAsync(async () =>
    //    {
    //        _forecasts = await WeatherApi.GetWeatherAsync(5, _cancellationTokenSource.Token);
    //        StateHasChanged();
    //    });
    //}

    protected override async Task OnInitializedAsync()
    {
        //_forecasts = await WeatherApi.GetWeatherAsync(5, _cancellationTokenSource.Token);
        await foreach (var forecasts in WeatherApi.GetWeatherStreamDataAsync(5, _cancellationTokenSource.Token))
        {
            _ = InvokeAsync(() =>
            {
                _forecasts.AddRange(forecasts);
                StateHasChanged();
            });
        }
    }

    void IDisposable.Dispose()
    {
        GC.SuppressFinalize(this);
        _cancellationTokenSource.Cancel();
        _cancellationTokenSource.Dispose();
    }
}