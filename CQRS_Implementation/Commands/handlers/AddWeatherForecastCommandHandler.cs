using CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_Implementation.Commands.handlers
{
    public class AddWeatherForecastCommandHandler : ICommandHandler<AddWeatherForecastCommand>
    {
        public  Task handleAsync(AddWeatherForecastCommand command)
        {
            return Task.Run(() => {
                Console.WriteLine("adding  weatherForecast");
                });
        }
    }
}
