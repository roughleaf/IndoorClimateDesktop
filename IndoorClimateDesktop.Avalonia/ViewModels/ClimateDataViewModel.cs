﻿using IndoorClimateDesktop.Domain.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using IndoorClimateDesktop.Services.ApiIndoorClimateLocalData;
using System.Collections.ObjectModel;
using IndoorClimateDesktop.Domain.Models.Climacell.AirQuality;

namespace IndoorClimateDesktop.Avalonia.ViewModels
{
    public class ClimateDataViewModel : ViewModelBase
    {
        ApiIndoorClimateLocalDataService apiIndoorClimateLocalDataService = new ApiIndoorClimateLocalDataService();        
        
        private ClimateData? nodeData;

        public ClimateData? NodeData
        {
            get { return nodeData; }
            private set => this.RaiseAndSetIfChanged(ref nodeData, value);
        }

        public ClimateDataViewModel()
        {
            NodeData = new ClimateData { MacAddress = "Waiting for connection..." };
        }       

        async void ButtonPushed()
        {
            string? apiKey = ConfigurationManager.AppSettings.Get("OpenWeatherApiKey");            
            NodeData = await ApiIndoorClimateLocalDataService.GetLocalClimateData();
        }       

    }
}
