using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace IndoorClimateDesktop.Avalonia.Views
{
    public class AirQualityView : UserControl
    {
        public AirQualityView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
