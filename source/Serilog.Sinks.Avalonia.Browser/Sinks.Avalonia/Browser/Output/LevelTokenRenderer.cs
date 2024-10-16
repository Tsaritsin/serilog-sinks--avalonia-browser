using Serilog.Events;
using Serilog.Parsing;
using Serilog.Sinks.Avalonia.Browser.Rendering;

namespace Serilog.Sinks.Avalonia.Browser.Output;

internal class LevelTokenRenderer(
    PropertyToken levelToken) : OutputTemplateTokenRenderer
{
    public override void Render(LogEvent logEvent,
                                TokenEmitter emitToken)
    {
        var moniker = LevelOutputFormat.GetLevelMoniker(logEvent.Level, levelToken.Format);
        var alignedOutput = Padding.Apply(moniker, levelToken.Alignment);
        emitToken(alignedOutput);
    }
}
