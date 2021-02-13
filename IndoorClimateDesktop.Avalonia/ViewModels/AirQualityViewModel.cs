using IndoorClimateDesktop.Domain.Models.Climacell.AirQuality;
using IndoorClimateDesktop.Domain.Services.ApiClimacel;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoorClimateDesktop.Avalonia.ViewModels
{
    public class AirQualityViewModel : ViewModelBase
    {
        ApiClimacelService apiClimacelService = new ApiClimacelService();

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
            AirData = await apiClimacelService.GetAirQualityAndPollenData(apiKey, location);
        }
    }
}
