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

    private readonly BrowserLogger _browserLogger = new();

    public void Emit(LogEvent logEvent)
    {
        ArgumentNullException.ThrowIfNull(logEvent);

        var args = _formatter.Format(logEvent);

        try
        {
            switch (logEvent.Level)
            {
                case LogEventLevel.Verbose:
                    _browserLogger.Debug(args);
                    break;
                case LogEventLevel.Debug:
                    _browserLogger.Debug(args);
                    break;
                case LogEventLevel.Information:
                    _browserLogger.Information(args);
                    break;
                case LogEventLevel.Warning:
                    _browserLogger.Warning(args);
                    break;
                case LogEventLevel.Error:
                    _browserLogger.Error(args);
                    break;
                case LogEventLevel.Fatal:
                    _browserLogger.Error(args);
                    break;
                default:
                    _browserLogger.Write(args);
                    break;
            }
        }
        catch (Exception ex)
        {
            SelfLog.WriteLine("Failed to emit log event: {0}", ex.Message);
        }
    }
}
