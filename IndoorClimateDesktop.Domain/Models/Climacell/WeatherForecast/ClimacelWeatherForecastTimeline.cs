using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Models.Climacell.WeatherForecast
{
    public class ClimacelWeatherForecastTimeline
    {
        public string timestep { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public IList<ClimacelWeatherForecastInterval> ClimacelWeatherForecastInterval { get; set; }
    }
}
