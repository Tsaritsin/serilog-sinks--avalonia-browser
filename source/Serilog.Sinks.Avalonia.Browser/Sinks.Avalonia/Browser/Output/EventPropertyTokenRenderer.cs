using Serilog.Events;
using Serilog.Parsing;
using Serilog.Sinks.Avalonia.Browser.Rendering;

namespace Serilog.Sinks.Avalonia.Browser.Output;

internal class EventPropertyTokenRenderer(
    PropertyToken token,
    IFormatProvider? formatProvider)
    : OutputTemplateTokenRenderer
{
    public override void Render(LogEvent logEvent,
                                TokenEmitter emitToken)
    {
        // If a property is missing, don't render anything (message templates render the raw token here).
        if (!logEvent.Properties.TryGetValue(token.PropertyName, out var propertyValue))
        {
            if (token.Alignment is not null)
                emitToken(Padding.Apply(string.Empty, token.Alignment));
            return;
        }

        var writer = new StringWriter();

        // If the value is a scalar string, support some additional formats: 'u' for uppercase
        // and 'w' for lowercase.
        if (propertyValue is ScalarValue { Value: string literalString })
        {
            var cased = Casing.Format(literalString, token.Format);
            writer.Write(cased);
        }
        else
        {
            propertyValue.Render(writer, token.Format, formatProvider);
        }

        var str = writer.ToString();
        if (token.Alignment is not null)
            emitToken(Padding.Apply(str, token.Alignment));
        else
            emitToken(str);
    }
}
