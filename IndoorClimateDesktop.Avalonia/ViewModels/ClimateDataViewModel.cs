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
using System.Collections.ObjectModel;

namespace IndoorClimateDesktop.Avalonia.ViewModels
{
    public class ClimateDataViewModel : ViewModelBase
    {
        ApiIndoorClimateLocalDataService apiIndoorClimateLocalDataService = new ApiIndoorClimateLocalDataService();

        private bool[] isVisible;

        public bool[] IsVisible
        {
            get { return isVisible; }
            private set => this.RaiseAndSetIfChanged(ref isVisible, value);
        }


        private ObservableCollection<NodeData> _nodeData;

        public ObservableCollection<NodeData> _NodeData
        {
            get { return _nodeData; }
            private set => this.RaiseAndSetIfChanged(ref _nodeData, value);
        }


        private string zeroText;

        public string ZeroText
        {
            get { return zeroText; }
            private set => this.RaiseAndSetIfChanged(ref zeroText, value);
        }

        private bool vistest;

        public bool Vistest
        {
            get { return vistest; }
            private set => this.RaiseAndSetIfChanged(ref vistest, value);
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
            Vistest = true;
            NodeData = new ClimateData { MacAddress = "Test0" };
        }

        private ObservableCollection<NodeData> displayStuff;

        public ObservableCollection<NodeData> DisplayStuff
        {
            get { return displayStuff; }
            private set => this.RaiseAndSetIfChanged(ref displayStuff, value);
        }


        public void ButtonPushed()
        {
            Vistest = !Vistest;
            string apiKey = ConfigurationManager.AppSettings.Get("OpenWeatherApiKey");
            ZeroText = "You pushed it";
            NodeData = ApiIndoorClimateLocalDataService.GetLocalClimateData();
            IsVisible = new bool[10] { false, false, false, false, false, false, false, false, false, false };
            DisplayStuff = new ObservableCollection<NodeData>((List<NodeData>)NodeData.NodeData);
        }

    }
}

//NodeDataTest = new ClimateDataTest
//{
//    DisplayStuff = new string[8]
//    {
//        NodeData.NodeData[9].NodeID.ToString(),
//        NodeData.NodeData[9].DateStamp,
//        NodeData.NodeData[9].TimeStamp,
//        NodeData.NodeData[9].BME280Temperature.ToString(),
//        NodeData.NodeData[9].BME280Pressure.ToString(),
//        NodeData.NodeData[9].BME280Humididty.ToString(),
//        NodeData.NodeData[9].DS18B20Temperature.ToString(),
//        NodeData.NodeData[9].RainCount.ToString(),
//    }
//};