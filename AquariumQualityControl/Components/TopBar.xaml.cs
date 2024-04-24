using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AquariumQualityControl.Components;

public partial class TopBar : UserControl
{
    private Window Window;

    public TopBar()
    {
        InitializeComponent();
        Loaded += TopBar_Loaded;
    }

    private void TopBar_Loaded(object sender, RoutedEventArgs e)
    {
        Window = Window.GetWindow(this);
    }

    #region Minimize, maximize and close actions

    private void MinimizeClick(object sender, RoutedEventArgs e)
    {
        Window.WindowState = WindowState.Minimized;
    }

    private void MaximizeClick(object sender, RoutedEventArgs e)
    {
        Window.WindowState = Window.WindowState is WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized;
    }

    private void CloseClick(object sender, RoutedEventArgs e)
    {
        Window.Close();
    }

    #endregion

    #region Mouse actions

    private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton is MouseButton.Left)
            Window.DragMove();
    }

    private void TopBar_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
        {
            Point currentPosition = e.GetPosition(null);
            Window.Left = currentPosition.X - (Window.Width / 2);
            Window.Top = currentPosition.Y - 15;
        }
    }

    #endregion
}