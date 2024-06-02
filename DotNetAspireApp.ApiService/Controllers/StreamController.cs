using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetAspireApp.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StreamController : ControllerBase
{
    // GET: api/<StreamController>

    [HttpGet]
    public async IAsyncEnumerable<WeatherForecast[]> Get()
    {
        for (int i = 0; i < new Random().Next(1, 100); i++)
        {
            await Task.Delay(1000);
            yield return Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    "Random"
                )).ToArray();
        }
    }

    // GET api/<StreamController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<StreamController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<StreamController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<StreamController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}