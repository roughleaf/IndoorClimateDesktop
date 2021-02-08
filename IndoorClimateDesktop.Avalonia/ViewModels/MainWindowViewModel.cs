using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndoorClimateDesktop.Avalonia.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        //ViewModelBase content;
        ViewModelBase nodeContent;
        ViewModelBase airQualityContent;
        ViewModelBase weatherForcastContent;

        public MainWindowViewModel()
        {
            nodeContent = ClimateDataView = new ClimateDataViewModel();
            airQualityContent = AirQualityView = new AirQualityViewModel();
            weatherForcastContent = WeatherForecastView = new WeatherForecastViewModel();
        }

        //public ViewModelBase Content
        //{
        //    get => content;
        //    private set => this.RaiseAndSetIfChanged(ref content, value);
        //}

        public ViewModelBase NodeContent
        {
            get => nodeContent;
            private set => this.RaiseAndSetIfChanged(ref nodeContent, value);
        }

        public ViewModelBase AirQualityContent
        {
            get => airQualityContent;
            private set => this.RaiseAndSetIfChanged(ref airQualityContent, value);
        }

        public ViewModelBase WeatherForcastContent
        {
            get => weatherForcastContent;
            private set => this.RaiseAndSetIfChanged(ref weatherForcastContent, value);
        }

        public ClimateDataViewModel ClimateDataView { get; }
        public AirQualityViewModel AirQualityView { get; }
        public WeatherForecastViewModel WeatherForecastView { get; }
    }
}
