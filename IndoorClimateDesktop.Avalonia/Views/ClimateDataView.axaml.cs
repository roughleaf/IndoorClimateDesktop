using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace IndoorClimateDesktop.Avalonia.Views
{
    public class ClimateDataView : UserControl
    {
        public ClimateDataView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
