using System.Runtime.Versioning;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.Avalonia.Browser;
using Serilog.Sinks.Avalonia.Browser.Output;

[assembly: SupportedOSPlatform("browser")]

namespace Serilog;

/// <summary>
///     Adds the WriteTo.Browser() extension method to <see cref="LoggerConfiguration" />.
/// </summary>
public static class LoggerConfigurationExtensions
{
    private const string SerilogToken =
        "%cserilog{_}color:white;background:#8c7574;border-radius:3px;padding:1px 2px;font-weight:600;";

    private const string DefaultConsoleOutputTemplate = SerilogToken + "{Message}{NewLine}{Exception}";

    /// <summary>
    ///     Writes log events to the browser console.
    /// </summary>
    /// <param name="sinkConfiguration">Logger sink configuration.</param>
    /// <param name="restrictedToMinimumLevel">
    ///     The minimum level for
    ///     events passed through the sink. Ignored when <paramref name="levelSwitch" /> is specified.
    /// </param>
    /// <param name="outputTemplate">
    ///     A message template describing the format used to write to the sink.
    ///     The default is <code>"[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"</code>.
    /// </param>
    /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
    /// <param name="levelSwitch">
    ///     A switch allowing the pass-through minimum level
    ///     to be changed at runtime.
    /// </param>
    /// <returns>Configuration object allowing method chaining.</returns>
    public static LoggerConfiguration Browser(
        this LoggerSinkConfiguration sinkConfiguration,
        LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
        string outputTemplate = DefaultConsoleOutputTemplate,
        IFormatProvider? formatProvider = null,
        LoggingLevelSwitch? levelSwitch = null)
    {
        ArgumentNullException.ThrowIfNull(sinkConfiguration);

        var formatter = new OutputTemplateRenderer(outputTemplate, formatProvider);

        return sinkConfiguration.Sink(new BrowserSink(formatter), restrictedToMinimumLevel, levelSwitch);
    }
}
