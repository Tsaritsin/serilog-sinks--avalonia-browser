using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Text.Json;

namespace Serilog.Sinks.Avalonia.Browser;

[SupportedOSPlatform("browser")]
internal partial class BrowserLogger
{
    [JSImport("globalThis.console.log")]
    internal static partial Task Log([JSMarshalAs<JSType.String>] string message);

    public void Write(object[] args)
    {
        var message = JsonSerializer.Serialize(args);

        Log(message);
    }

    [JSImport("globalThis.console.error")]
    internal static partial Task LogError([JSMarshalAs<JSType.String>] string message);

    public void Error(object[] args)
    {
        var message = JsonSerializer.Serialize(args);

        LogError(message);
    }

    [JSImport("globalThis.console.warn")]
    internal static partial Task LogWarning([JSMarshalAs<JSType.String>] string message);

    public void Warning(object[] args)
    {
        var message = JsonSerializer.Serialize(args);

        LogWarning(message);
    }

    [JSImport("globalThis.console.debug")]
    internal static partial void LogDebug([JSMarshalAs<JSType.String>] string message);

    public void Debug(object[] args)
    {
        var message = JsonSerializer.Serialize(args);

        LogDebug(message);
    }

    [JSImport("globalThis.console.info")]
    internal static partial Task LogInformation([JSMarshalAs<JSType.String>] string message);

    public void Information(object[] args)
    {
        var message = JsonSerializer.Serialize(args);

        LogInformation(message);
    }
}
