using System.Runtime.Versioning;
using Serilog.Core;
using Serilog.Debugging;
using Serilog.Events;
using Serilog.Sinks.Avalonia.Browser.Output;

namespace Serilog.Sinks.Avalonia.Browser;

[SupportedOSPlatform("browser")]
internal class BrowserSink(
    OutputTemplateRenderer formatter) : ILogEventSink
{
    private readonly OutputTemplateRenderer
        _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));

    public void Emit(LogEvent logEvent)
    {
        ArgumentNullException.ThrowIfNull(logEvent);

        var args = _formatter.Format(logEvent);

        try
        {
            switch (logEvent.Level)
            {
                case LogEventLevel.Verbose:
                case LogEventLevel.Debug:
                    BrowserLogger.Debug(args[0], args[1], args[2], args[3]);
                    break;
                case LogEventLevel.Information:
                    BrowserLogger.Info(args[0], args[1], args[2], args[3]);
                    break;
                case LogEventLevel.Warning:
                    BrowserLogger.Warning(args[0], args[1], args[2], args[3]);
                    break;
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    if (args.Length == 5)
                    {
                        BrowserLogger.Error(args[0], args[1], args[2], args[3], args[4]);
                    }
                    else
                    {
                        BrowserLogger.Error(args[0], args[1], args[2], args[3]);
                    }

                    break;
                default:
                    BrowserLogger.Log(args[0], args[1], args[2], args[3]);
                    break;
            }
        }
        catch (Exception ex)
        {
            SelfLog.WriteLine("Failed to emit log event: {0}", ex.Message);
        }
    }
}
