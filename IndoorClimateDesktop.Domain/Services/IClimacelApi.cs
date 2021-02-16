using IndoorClimateDesktop.Domain.Models.Climacell.AirQuality;
using IndoorClimateDesktop.Domain.Models.Climacell.WeatherForecast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Services
{
    public interface IClimacelApi
    {
        Task<ClimacelAirQualityAndPollenData> GetAirQualityAndPollenData(string apiKey, string locationId);
        Task<ClimacelWeatherForecastData> GetClimacelWeatherForecast(string apiKey, string locationId);
    }
}
