using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndoorClimateDesktop.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;

        public MainWindowViewModel()
        {
            content = ClimateDataView = new ClimateDataViewModel();
        }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public ClimateDataViewModel ClimateDataView { get; }
    }
}
