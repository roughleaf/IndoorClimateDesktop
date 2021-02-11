using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Models.Climacell.WeatherForecast
{
    public class ClimacelWeatherForecastInterval
    {
        public DateTime startTime { get; set; }
        public ClimacelWeatherForcastValues ClimacelWeatherForcastValues { get; set; }
    }
}
