using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using Hc = HandyControl.Controls;


namespace Snap_Screen;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Hc.Window
{
    private Point startPoint;
    private bool resizing = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        startPoint = e.GetPosition(this);
        resizing = true;
        Mouse.Capture((UIElement)sender);
    }

    private void Border_MouseMove(object sender, MouseEventArgs e)
    {
        if (resizing)
        {
            Point endPoint = e.GetPosition(this);
            double deltaX = endPoint.X - startPoint.X;
            double deltaY = endPoint.Y - startPoint.Y;

            Border border = (Border)sender;
            border.Width += deltaX;
            border.Height += deltaY;

            startPoint = endPoint;
        }
    }

    private void Border_MouseUp(object sender, MouseButtonEventArgs e)
    {
        resizing = false;
        Mouse.Capture(null);
    }

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        this.DragMove();
    }
}