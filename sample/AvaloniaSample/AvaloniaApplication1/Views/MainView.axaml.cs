using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Serilog;

namespace AvaloniaApplication1.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void HandleDebugButtonClick(object? sender,
                                        RoutedEventArgs e)
    {
        Log.Debug("DebugButton clicked");
    }

    private void HandleInfoButtonClick(object? sender,
                                       RoutedEventArgs e)
    {
        Log.Information("InformationButton clicked");
    }

    private void HandleWarningButtonClick(object? sender,
                                          RoutedEventArgs e)
    {
        Log.Warning("WarningButton clicked");
    }

    private void HandleErrorButtonClick(object? sender,
                                        RoutedEventArgs e)
    {
        Log.Error("ErrorButton clicked");
    }

    private void HandleFatalButtonClick(object? sender,
                                        RoutedEventArgs e)
    {
        Log.Fatal(new Exception("Exception trow"), "ErrorButton clicked");
    }
}
