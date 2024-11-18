using System;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using Serilog;
using Serilog.Debugging;

[assembly: SupportedOSPlatform("browser")]

namespace AvaloniaApplication1.Browser;

internal sealed partial class Program
{
    private static Task Main(string[] args)
    {
        SelfLog.Enable(m => Console.Error.WriteLine(m));

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Browser()
            .CreateLogger()
            .ForContext<Program>();

        Log.Information("Hello, browser!");

        return AppBuilder
            .Configure<App>()
            .WithInterFont()
            .StartBrowserAppAsync("out");
    }
}
