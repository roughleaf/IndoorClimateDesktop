using IndoorClimateDesktop.Domain.Models.Climacell.AirQuality;
using IndoorClimateDesktop.Services.ApiClimacel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Services
{
    public interface IClimacelApi
    {
        Task<ClimacelAirQualityAndPollenData> GetAirQualityAndPollenData(string apiKey, string locationId);
        Task<ApiClimacelWeatherForecast> GetClimacelWeatherForecast(string apiKey, string locationId);
    }
}
