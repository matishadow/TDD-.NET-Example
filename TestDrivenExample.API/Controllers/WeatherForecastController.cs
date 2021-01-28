using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestDrivenExample.ExampleModule.PublicClasses;

namespace TestDrivenExample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ITemperatureConverter _temperatureConverter;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            ITemperatureConverter temperatureConverter)
        {
            _logger = logger;
            _temperatureConverter = temperatureConverter;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index =>
                {
                    int r = rng.Next(-20, 55);

                    return new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = r,
                        TemperatureKelvins = _temperatureConverter.ConvertFromCelsiusToKelvin(r),
                        Summary = Summaries[rng.Next(Summaries.Length)]
                    };
                })
                .ToArray();
        }
    }
}