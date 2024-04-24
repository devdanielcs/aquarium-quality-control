using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace AquariumQualityControl;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ToggleMenu(object sender, RoutedEventArgs e)
    {
        DoubleAnimation animation = new()
        {
            Duration = TimeSpan.FromSeconds(0.2),
            To = menuGrid.Width is 150
                ? 40
                : 150
        };

        menuGrid.BeginAnimation(WidthProperty, animation);
    }

    #region Top bar actions

    private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton is MouseButton.Left)
            DragMove();
    }

    private void TopBar_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
        {
            Point currentPosition = e.GetPosition(this);
            Left = currentPosition.X - (Width / 2);
            Top = currentPosition.Y - 15;
        }
    }

    #endregion

    #region Minimize Maximize Close

    private void MaximizeClick(object sender, RoutedEventArgs e) =>
        WindowState = WindowState is WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized;

    private void MinimizeClick(object sender, RoutedEventArgs e) =>
        WindowState = WindowState.Minimized;

    private void CloseClick(object sender, RoutedEventArgs e) =>
        Close();

    #endregion
}