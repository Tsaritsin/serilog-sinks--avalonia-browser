using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Serilog.Sinks.Avalonia.Browser;

/// <summary>
///     Provides methods to log messages to the browser's console.
/// </summary>
[SupportedOSPlatform("browser")]
internal static partial class BrowserLogger
{
    [JSImport("globalThis.console.log")]
    public static partial void Log([JSMarshalAs<JSType.String>] string message);

    [JSImport("globalThis.console.debug")]
    public static partial void Debug(
        [JSMarshalAs<JSType.String>] string labelText,
        [JSMarshalAs<JSType.String>] string labelFormat,
        [JSMarshalAs<JSType.String>] string message);

    [JSImport("globalThis.console.info")]
    public static partial void Info(
        [JSMarshalAs<JSType.String>] string labelText,
        [JSMarshalAs<JSType.String>] string labelFormat,
        [JSMarshalAs<JSType.String>] string message);

    [JSImport("globalThis.console.warn")]
    public static partial void Warning(
        [JSMarshalAs<JSType.String>] string labelText,
        [JSMarshalAs<JSType.String>] string labelFormat,
        [JSMarshalAs<JSType.String>] string message);

    [JSImport("globalThis.console.error")]
    public static partial void Error(
        [JSMarshalAs<JSType.String>] string labelText,
        [JSMarshalAs<JSType.String>] string labelFormat,
        [JSMarshalAs<JSType.String>] string message);
}
