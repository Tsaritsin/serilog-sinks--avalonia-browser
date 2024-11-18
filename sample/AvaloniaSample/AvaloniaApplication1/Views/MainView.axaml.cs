using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Serilog;

namespace AvaloniaApplication1.Views;

public partial class MainView : UserControl
{
    private readonly ILogger _logger = Log.ForContext<MainView>();

    public MainView()
    {
        InitializeComponent();
    }

    private void HandleDebugButtonClick(object? sender,
                                        RoutedEventArgs e)
    {
        _logger.Debug("DebugButton clicked");
    }

    private void HandleInfoButtonClick(object? sender,
                                       RoutedEventArgs e)
    {
        _logger.Information("InformationButton clicked");
    }

    private void HandleWarningButtonClick(object? sender,
                                          RoutedEventArgs e)
    {
        _logger.Warning("WarningButton clicked");
    }

    private void HandleErrorButtonClick(object? sender,
                                        RoutedEventArgs e)
    {
        _logger.Error("ErrorButton clicked");
    }

    private void HandleFatalButtonClick(object? sender,
                                        RoutedEventArgs e)
    {
        _logger.Fatal(new Exception("Exception trow"), "FatalButton clicked");
    }

    private void HandleDestructButtonClick(object? sender,
                                           RoutedEventArgs e)
    {
        var testRecord = new MyRecord("Test", 10);

        //_logger.Information("DestructButton clicked {Age}", testRecord.Age);
        _logger.Information("DestructButton clicked {@testRecord}", testRecord);
    }
}

public record MyRecord(
    string Name,
    int Age);
