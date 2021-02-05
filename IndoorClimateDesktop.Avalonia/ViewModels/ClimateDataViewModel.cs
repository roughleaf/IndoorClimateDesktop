using IndoorClimateDesktop.Domain.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace IndoorClimateDesktop.Avalonia.ViewModels
{
    public class ClimateDataViewModel : ViewModelBase
    {
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


        public ClimateDataViewModel()
        {
            ZeroText = "Whatever";
            NodeData = new ClimateData { macAddress = "Test0" };
        }

        public void ButtonPushed()
        {
            ZeroText = "You pushed it";
            NodeData = new ClimateData { macAddress = ConfigurationManager.AppSettings.Get("OpenWeatherApiKey") };
        }

    }
}
