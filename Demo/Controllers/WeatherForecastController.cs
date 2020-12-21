using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS;
using CQRS.Command;
using CQRS_Implementation.Commands.handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CQRS_Implementation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ICommandDispatcher commandDispatcher)
        {
            _logger = logger;

            commandDispatcher.send(new AddWeatherForecastCommand());
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
