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
using IndoorClimateDesktop.Domain.Models.Climacell.AirQuality;
using IndoorClimateDesktop.Domain.Services;

namespace IndoorClimateDesktop.Avalonia.ViewModels
{
    public class ClimateDataViewModel : ViewModelBase, IObserver<ClimateData>
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
            NodeData = new ClimateData { MacAddress = "Waiting for client..." };
            apiIndoorClimateLocalDataService.Subscribe(this);
            apiIndoorClimateLocalDataService.GetLocalClimateData();     // This should start the service
        }

        public void OnCompleted()
        {
            // Do Nothing
        }

        public void OnError(Exception error)
        {
            // Do Nothing
        }

        public void OnNext(ClimateData value)       // This even is called every time data is received on my TCP socket 
        {
            NodeData = value;
        }
    }
}
