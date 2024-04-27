using System.Windows;
using System.Windows.Input;

namespace AquariumQualityControl;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    #region TopBar Methods

    private void CloseClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void TopBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton is MouseButton.Left)
            DragMove();
    }

    private void TopBar_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton is MouseButtonState.Pressed)
        {
            Point currentPosition = e.GetPosition(null);
            Left = currentPosition.X - (Width / 2);
            Top = currentPosition.Y - 15;
        }
    }

    #endregion

    #region Load pages Methods

    private void Load_HomePage(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new Uri(
            "/Pages/HomePage.xaml",
            UriKind.Relative));
    }

    private void Load_AmmoniaPage(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new Uri(
            "/Pages/AmmoniaPage.xaml",
            UriKind.Relative));
    }

    #endregion
}