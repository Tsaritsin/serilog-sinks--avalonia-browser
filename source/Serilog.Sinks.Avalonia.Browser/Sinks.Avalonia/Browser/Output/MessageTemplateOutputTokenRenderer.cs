using Serilog.Events;
using Serilog.Parsing;

namespace Serilog.Sinks.Avalonia.Browser.Output;

internal class MessageTemplateOutputTokenRenderer : OutputTemplateTokenRenderer
{
    public override void Render(LogEvent logEvent,
                                TokenEmitter emitToken)
    {
        foreach (var token in logEvent.MessageTemplate.Tokens)
            switch (token)
            {
                case TextToken tt:
                    emitToken(tt.Text);
                    break;
                case PropertyToken pt:
                    if (logEvent.Properties.TryGetValue(pt.PropertyName, out var propertyValue))
                        emitToken(ObjectModelInterop.ToInteropValue(propertyValue));
                    break;
                default:
                    throw new InvalidOperationException();
            }
    }
}
