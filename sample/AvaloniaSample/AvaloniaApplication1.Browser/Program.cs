using System;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using AvaloniaApplication1;
using Serilog;
using Serilog.Debugging;

[assembly: SupportedOSPlatform("browser")]

internal sealed partial class Program
{
    private static Task Main(string[] args)
    {
        SelfLog.Enable(m => Console.Error.WriteLine(m));

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .CreateLogger();

        return BuildAvaloniaApp()
            .WithInterFont()
            .StartBrowserAppAsync("out");
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>();
    }
}
