using Serilog.Events;

namespace Serilog.Sinks.Avalonia.Browser.Output;

delegate void TokenEmitter(object? token);

abstract class OutputTemplateTokenRenderer
{
    public abstract void Render(LogEvent logEvent, TokenEmitter emitToken);
}
