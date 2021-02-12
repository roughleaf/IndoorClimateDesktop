using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Services.ApiClimacel.Models
{
    public class ApiClimacelWeatherForecast
    {
        public ForecastData data { get; set; }
    }

    public class ForecastData
    {
        public IEnumerable<ForecastTimeline> timelines { get; set; }
    }

    public class ForecastTimeline
    {
        public string timestep { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public IEnumerable<ForecastInterval> intervals { get; set; }
    }

    public class ForecastInterval
    {
        public DateTime startTime { get; set; }
        public ForecastValues values { get; set; }
    }

    public class ForecastValues
    {
        public float temperature { get; set; }
        public float temperatureApparent { get; set; }
        public float humidity { get; set; }
        public float windSpeed { get; set; }
        public float windDirection { get; set; }
        public float pressureSurfaceLevel { get; set; }
        public float precipitationIntensity { get; set; }
        public int precipitationProbability { get; set; }
        public DateTime sunriseTime { get; set; }
        public DateTime sunsetTime { get; set; }
        public float cloudCover { get; set; }
        public int moonPhase { get; set; }
        public int weatherCode { get; set; }
    }

}
