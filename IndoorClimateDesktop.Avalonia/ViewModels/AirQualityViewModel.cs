using IndoorClimateDesktop.Domain.Models.Climacell.AirQuality;
using IndoorClimateDesktop.Domain.Services.ApiClimacel;
using IndoorClimateDesktop.Domain.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndoorClimateDesktop.Services;

namespace IndoorClimateDesktop.Avalonia.ViewModels
{
    public class AirQualityViewModel : ViewModelBase
    {
        //ApiClimacelService apiClimacelService = new ApiClimacelService();
        readonly IClimacelApi climacelApi = new ApiClimacelService();

        private ClimacelAirQualityAndPollenData? airData;

        public ClimacelAirQualityAndPollenData? AirData
        {
            get { return airData; }
            private set => this.RaiseAndSetIfChanged(ref airData, value);
        }

        public AirQualityViewModel()
        {
            AirData = new ClimacelAirQualityAndPollenData();
        }

        public void GetApiAirQualityData()
        {
            string? climacelApiKey = ConfigurationManager.AppSettings.Get("ClimacelApiKey");
            string? climacelLocationId = ConfigurationManager.AppSettings.Get("ClimacelHomeLocationId");
            GetAirQualityAsync(climacelLocationId, climacelApiKey);
        }

        async void GetAirQualityAsync(string location, string apiKey)
        {
            //AirData = await apiClimacelService.GetAirQualityAndPollenData(apiKey, location);
            try     // Intermittend array out of bound exception. Going to attempt to modify my models to see if that eliminates the problem.
            {
                AirData = await climacelApi.GetAirQualityAndPollenData(apiKey, location);
            }
            catch
            {

            }
        }
    }
}
