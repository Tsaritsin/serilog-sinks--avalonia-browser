using Serilog.Events;
using Serilog.Parsing;

namespace Serilog.Sinks.Avalonia.Browser.Output;

internal class PropertiesTokenRenderer(
    PropertyToken token,
    MessageTemplate outputTemplate) : OutputTemplateTokenRenderer
{
    public override void Render(LogEvent logEvent,
                                TokenEmitter emitToken)
    {
        var included = logEvent.Properties
            .Where(p => !TemplateContainsPropertyName(logEvent.MessageTemplate, p.Key) &&
                        !TemplateContainsPropertyName(outputTemplate, p.Key))
            .Select(p => new LogEventProperty(p.Key, p.Value));

        foreach (var property in included)
        {
            emitToken(ObjectModelInterop.ToInteropValue(property.Value, token.Format));
        }
    }

    private static bool TemplateContainsPropertyName(MessageTemplate template,
                                                     string propertyName)
    {
        foreach (var token in template.Tokens)
        {
            if (token is PropertyToken namedProperty &&
                namedProperty.PropertyName == propertyName)
            {
                return true;
            }
        }

        return false;
    }
}
