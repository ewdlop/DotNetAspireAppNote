var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapGet("/streamdata", async (HttpContext httpContext) =>
{
    // Set the response content type
    httpContext.Response.ContentType = "application/json";

    // Use an async enumerator to stream the data
    foreach (var item in GetData())
    {
        // Write each item to the response stream
        await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(item));
        // Add a newline for better readability
        await httpContext.Response.WriteAsync("\n");
    }
});

app.MapDefaultEndpoints();

app.Run();

static IEnumerable<WeatherForecast> GetData()
{
    for (int i = 0; i < new Random().Next(1, 100); i++)
    {
        yield return new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(i)),
            Random.Shared.Next(-20, 55),
            "Random"
        );
    }
}

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}