using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AquariumQualityControl.Components;

public partial class MenuLayout : UserControl
{
    public MenuLayout()
    {
        InitializeComponent();
    }

    private void ToggleMenu(object sender, RoutedEventArgs e)
    {
        DoubleAnimation animation = new()
        {
            Duration = TimeSpan.FromSeconds(0.2),
            To = menuGrid.Width is 150 ? 40 : 150
        };

        menuGrid.BeginAnimation(WidthProperty, animation);
    }
}