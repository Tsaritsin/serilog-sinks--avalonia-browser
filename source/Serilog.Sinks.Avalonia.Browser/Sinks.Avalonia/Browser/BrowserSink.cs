using System.Runtime.Versioning;
using Serilog.Core;
using Serilog.Debugging;
using Serilog.Events;
using Serilog.Formatting;

namespace Serilog.Sinks.Avalonia.Browser;

/// <summary>
///     Provides a sink for Serilog that outputs log events to the browser console.
/// </summary>
[SupportedOSPlatform("browser")]
internal class BrowserSink(
    ITextFormatter formatter) : ILogEventSink
{
    private const string SerilogLabel =
        "%cserilog";

    private const string SerilogFormatDebug =
        "color: #388e3c; background: #e8f5e9; border-radius: 3px; padding: 1px 2px; font-weight: bold;";

    private const string SerilogFormatInfo =
        "color: #1976d2; background: #e3f2fd; border-radius: 3px; padding: 1px 2px; font-weight: bold;";

    private const string SerilogFormatWarning =
        "color: #f57f17; background: #fff8e1; border-radius: 3px; padding: 1px 2px; font-weight: bold;";

    private const string SerilogFormatError =
        "color: #d32f2f; background: #ffebee; border-radius: 3px; padding: 1px 2px; font-weight: bold;";

    public void Emit(LogEvent logEvent)
    {
        using var buffer = new StringWriter();

        try
        {
            formatter.Format(logEvent, buffer);

            var message = buffer.ToString();

            switch (logEvent.Level)
            {
                case LogEventLevel.Verbose:
                case LogEventLevel.Debug:
                    BrowserLogger.Debug(SerilogLabel, SerilogFormatDebug, message);
                    break;
                case LogEventLevel.Information:
                    BrowserLogger.Info(SerilogLabel, SerilogFormatInfo, message);
                    break;
                case LogEventLevel.Warning:
                    BrowserLogger.Warning(SerilogLabel, SerilogFormatWarning, message);
                    break;
                case LogEventLevel.Error:
                case LogEventLevel.Fatal:
                    BrowserLogger.Error(SerilogLabel, SerilogFormatError, message);
                    break;
                default:
                    BrowserLogger.Log(message);
                    break;
            }
        }
        catch (Exception ex)
        {
            SelfLog.WriteLine("Failed to emit log event: {0}", ex.Message);
        }
    }
}
