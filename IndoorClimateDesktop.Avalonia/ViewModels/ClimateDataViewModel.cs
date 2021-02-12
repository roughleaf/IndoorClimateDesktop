using IndoorClimateDesktop.Domain.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using IndoorClimateDesktop.Services.ApiIndoorClimateLocalData;
using System.Collections.ObjectModel;
using IndoorClimateDesktop.Domain.Services.ApiClimacel;
using IndoorClimateDesktop.Domain.Models.Climacell.AirQuality;

namespace IndoorClimateDesktop.Avalonia.ViewModels
{
    public class ClimateDataViewModel : ViewModelBase
    {
        ApiIndoorClimateLocalDataService apiIndoorClimateLocalDataService = new ApiIndoorClimateLocalDataService();
        ApiClimacelService apiClimacelService = new ApiClimacelService();
        
        private ClimateData? nodeData;

        public ClimateData? NodeData
        {
            get { return nodeData; }
            private set => this.RaiseAndSetIfChanged(ref nodeData, value);
        }

        private ClimacelAirQualityAndPollenData airData;

        public ClimacelAirQualityAndPollenData AirData
        {
            get { return airData; }
            private set => this.RaiseAndSetIfChanged(ref airData, value);
        }


        public ClimateDataViewModel()
        {
            NodeData = new ClimateData { MacAddress = "Waiting for connection..." };
            airData = new ClimacelAirQualityAndPollenData();
        }       

        public async Task ButtonPushed()
        {
            string? apiKey = ConfigurationManager.AppSettings.Get("OpenWeatherApiKey");
            string? climacelApiKey = ConfigurationManager.AppSettings.Get("ClimacelApiKey");
            string? climacelLocationId = ConfigurationManager.AppSettings.Get("ClimacelHomeLocationId");
            NodeData = ApiIndoorClimateLocalDataService.GetLocalClimateData();
            await GetAirQualityAsync(climacelLocationId, climacelApiKey);
        }

        async Task GetAirQualityAsync(string location, string apiKey)
        {
            airData = await apiClimacelService.GetAirQualityAndPollenData(apiKey, location);
        }

    }
}
