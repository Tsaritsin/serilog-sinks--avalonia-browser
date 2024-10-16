using Serilog.Events;

namespace Serilog.Sinks.Avalonia.Browser.Output;

internal class ExceptionTokenRenderer : OutputTemplateTokenRenderer
{
    public override void Render(LogEvent logEvent, TokenEmitter emitToken)
    {
        if (logEvent.Exception is not null)
            emitToken(logEvent.Exception.ToString());
    }
}
