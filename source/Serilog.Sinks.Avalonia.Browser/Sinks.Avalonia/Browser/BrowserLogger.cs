using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Serilog.Sinks.Avalonia.Browser;

/// <summary>
/// Provides methods to log messages to the browser's console.
/// </summary>
[SupportedOSPlatform("browser")]
internal static partial class BrowserLogger
{
    [JSImport("globalThis.console.log")]
    public static partial void Log([JSMarshalAs<JSType.Any>] object title,
                                   [JSMarshalAs<JSType.Any>] object titleFormat,
                                   [JSMarshalAs<JSType.Any>] object message,
                                   [JSMarshalAs<JSType.Any>] object newLine);

    [JSImport("globalThis.console.debug")]
    public static partial void Debug([JSMarshalAs<JSType.Any>] object title,
                                     [JSMarshalAs<JSType.Any>] object titleFormat,
                                     [JSMarshalAs<JSType.Any>] object message,
                                     [JSMarshalAs<JSType.Any>] object newLine);

    [JSImport("globalThis.console.info")]
    public static partial void Info([JSMarshalAs<JSType.Any>] object title,
                                    [JSMarshalAs<JSType.Any>] object titleFormat,
                                    [JSMarshalAs<JSType.Any>] object message,
                                    [JSMarshalAs<JSType.Any>] object newLine);

    [JSImport("globalThis.console.warn")]
    public static partial void Warning([JSMarshalAs<JSType.Any>] object title,
                                       [JSMarshalAs<JSType.Any>] object titleFormat,
                                       [JSMarshalAs<JSType.Any>] object message,
                                       [JSMarshalAs<JSType.Any>] object newLine);

    [JSImport("globalThis.console.error")]
    public static partial void Error([JSMarshalAs<JSType.Any>] object title,
                                     [JSMarshalAs<JSType.Any>] object titleFormat,
                                     [JSMarshalAs<JSType.Any>] object message,
                                     [JSMarshalAs<JSType.Any>] object newLine);

    [JSImport("globalThis.console.error")]
    public static partial void Error([JSMarshalAs<JSType.Any>] object title,
                                     [JSMarshalAs<JSType.Any>] object titleFormat,
                                     [JSMarshalAs<JSType.Any>] object message,
                                     [JSMarshalAs<JSType.Any>] object newLine,
                                     [JSMarshalAs<JSType.Any>] object exception);
}
