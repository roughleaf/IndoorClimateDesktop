using IndoorClimateDesktop.Domain.Models.Climacell.AirQuality;
using IndoorClimateDesktop.Domain.Services.ApiClimacel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Domain.Services.ApiClimacel
{
    public class ApiClimacelService : IClimacelApi
    {
        public async Task<ClimacelAirQualityAndPollenData> GetAirQualityAndPollenData(string apiKey, string locationId)
        {
            using (HttpClient client = new HttpClient())
            {
                const string baseUri = "https://data.climacell.co/v4/timelines?";
                string locationUri = "location=" + locationId;
                const string fieldsUri = "&fields=particulateMatter25" +
                    "&fields=particulateMatter10" +
                    "&fields=pollutantO3&fields=pollutantNO2" +
                    "&fields=pollutantCO&fields=pollutantSO2" +
                    "&fields=treeIndex&fields=grassIndex" +
                    "&fields=grassGrassIndex" +
                    "&fields=weedIndex&fields=weedRagweedIndex";
                const string optionsUri = "&timesteps=current&units=metric" +
                    "&timezone=Africa/Johannesburg";
                string apiKeyUri = "&apikey=" + apiKey;

                string requestUri = baseUri + locationUri + fieldsUri + optionsUri + apiKeyUri;

                HttpResponseMessage apiResponse = await client.GetAsync(requestUri);

                string jsonResponse = await apiResponse.Content.ReadAsStringAsync();

                var opts = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                ApiClimacelAirQualityAndPollen apiClimacelAirQualityAndPollen = JsonSerializer.Deserialize<ApiClimacelAirQualityAndPollen>(jsonResponse, opts);

                ClimacelAirQualityAndPollenData climacelAirQualityAndPollenData = new ClimacelAirQualityAndPollenData();

                //return climacelAirQualityAndPollenData;
                return (ClimacelAirQualityAndPollenData)apiClimacelAirQualityAndPollen.data.timelines.Select(airQualityTimeline => new ClimacelAirQualityAndPollenData()
                {
                    TimeStamp = airQualityTimeline.startTime,
                    ClimacelAirQuality = (ClimacelAirQuality)airQualityTimeline.intervals.Select(climacelAirQuality => new ClimacelAirQuality
                    {
                        ParticulateMatter10 = climacelAirQuality.values.particulateMatter10,
                        ParticulateMatter25 = climacelAirQuality.values.particulateMatter25,
                        PollutantCO = climacelAirQuality.values.pollutantCO,
                        PollutantNO2 = climacelAirQuality.values.pollutantNO2,
                        PollutantO3 = climacelAirQuality.values.pollutantO3,
                        PollutantSO2 = climacelAirQuality.values.pollutantSO2
                    }),
                    ClimacelPollenIndex = (ClimacelPollenIndex)airQualityTimeline.intervals.Select(climacelPollenIndex => new ClimacelPollenIndex
                    {
                        GrassGrassIndex = climacelPollenIndex.values.grassGrassIndex,
                        GrassIndex = climacelPollenIndex.values.grassIndex,
                        TreeIndex = climacelPollenIndex.values.treeIndex,
                        WeedIndex = climacelPollenIndex.values.weedIndex,
                        WeedRagweedIndex = climacelPollenIndex.values.weedRagweedIndex
                    })
                });
            }
        }

        public Task<ApiClimacelWeatherForecast> GetClimacelWeatherForecast(string apiKey, string locationId)
        {
            throw new NotImplementedException();
        }
    }
}
