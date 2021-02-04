using IndoorClimateDesktop.Domain.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            ZeroText = "Test";
            NodeData = new ClimateData { macAddress = "Test0" };
        }

        public void ButtonPushed()
        {
            ZeroText = "You pushes it";
            NodeData = new ClimateData { macAddress = "Test1" };
        }

    }
}
