using IndoorClimateDesktop.Domain.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using IndoorClimateDesktop.Services.ApiIndoorClimateLocalData;
using IndoorClimateDesktop.Domain.Models.TestModels;

namespace IndoorClimateDesktop.Avalonia.ViewModels
{
    public class ClimateDataViewModel : ViewModelBase
    {
        ApiIndoorClimateLocalDataService apiIndoorClimateLocalDataService = new ApiIndoorClimateLocalDataService();
        private string zeroText;

        public string ZeroText
        {
            get { return zeroText; }
            private set => this.RaiseAndSetIfChanged(ref zeroText, value);
        }

        private ClimateData nodeData;

        public ClimateData NodeData
        {
            get { return nodeData; }
            private set => this.RaiseAndSetIfChanged(ref nodeData, value);
        }

        private ClimateDataTest nodeDataTest;

        public ClimateDataTest NodeDataTest
        {
            get { return nodeDataTest; }
            private set => this.RaiseAndSetIfChanged(ref nodeDataTest, value);
        }

        public ClimateDataViewModel()
        {
            ZeroText = "Whatever";
            NodeData = new ClimateData { MacAddress = "Test0" };
        }

        public void ButtonPushed()
        {
            string apiKey = ConfigurationManager.AppSettings.Get("OpenWeatherApiKey");
            ZeroText = "You pushed it";
            NodeData = ApiIndoorClimateLocalDataService.GetLocalClimateData();
            NodeDataTest = new ClimateDataTest
            {
                DisplayStuff = new string[8]
                {
                    NodeData.NodeData[9].NodeID.ToString(),
                    NodeData.NodeData[9].DateStamp,
                    NodeData.NodeData[9].TimeStamp,
                    NodeData.NodeData[9].BME280Temperature.ToString(),
                    NodeData.NodeData[9].BME280Pressure.ToString(),
                    NodeData.NodeData[9].BME280Humididty.ToString(),
                    NodeData.NodeData[9].DS18B20Temperature.ToString(),
                    NodeData.NodeData[9].RainCount.ToString(),
                }
            };
        }

    }
}
