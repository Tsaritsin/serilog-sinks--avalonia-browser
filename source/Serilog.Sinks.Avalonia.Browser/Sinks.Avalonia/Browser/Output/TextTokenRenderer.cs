using Serilog.Events;

namespace Serilog.Sinks.Avalonia.Browser.Output;

internal class TextTokenRenderer(
    string text) : OutputTemplateTokenRenderer
{
    public override void Render(LogEvent logEvent, TokenEmitter emitToken)
    {
        emitToken(text);
    }
}
