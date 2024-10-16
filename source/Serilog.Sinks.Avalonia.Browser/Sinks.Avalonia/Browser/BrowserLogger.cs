using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Serilog.Sinks.Avalonia.Browser;

[SupportedOSPlatform("browser")]
internal partial class BrowserLogger
{
    [JSImport("globalThis.console.log")]
    internal static partial Task Log([JSMarshalAs<JSType.Array<JSType.Object>>] object[] args);

    public void Write(object[] args)
    {
        Log(args);
    }

    [JSImport("globalThis.console.error")]
    internal static partial Task LogError([JSMarshalAs<JSType.Array<JSType.Object>>] object[] args);

    public void Error(object[] args)
    {
        LogError(args);
    }

    [JSImport("globalThis.console.warn")]
    internal static partial Task LogWarning([JSMarshalAs<JSType.Array<JSType.Object>>] object[] args);

    public void Warning(object[] args)
    {
        LogWarning(args);
    }

    [JSImport("globalThis.console.debug")]
    internal static partial void LogDebug([JSMarshalAs<JSType.Array<JSType.Object>>] object[] args);

    public void Debug(object[] args)
    {
        LogDebug(args);
    }

    [JSImport("globalThis.console.info")]
    internal static partial Task LogInformation([JSMarshalAs<JSType.Array<JSType.Object>>] object[] args);

    public void Information(object[] args)
    {
        LogInformation(args);
    }
}
