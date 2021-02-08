using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace IndoorClimateDesktop.Avalonia.Views
{
    public class WeatherForecastView : UserControl
    {
        public WeatherForecastView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
