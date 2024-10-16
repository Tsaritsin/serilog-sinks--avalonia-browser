using Serilog.Events;
using Serilog.Parsing;
using Serilog.Sinks.Avalonia.Browser.Rendering;

namespace Serilog.Sinks.Avalonia.Browser.Output;

internal class NewLineTokenRenderer(
    Alignment? alignment) : OutputTemplateTokenRenderer
{
    public override void Render(LogEvent logEvent,
                                TokenEmitter emitToken)
    {
        if (alignment is not null)
            emitToken(Padding.Apply(Environment.NewLine, alignment.Value.Widen(Environment.NewLine.Length)));
        else
            emitToken(Environment.NewLine);
    }
}
