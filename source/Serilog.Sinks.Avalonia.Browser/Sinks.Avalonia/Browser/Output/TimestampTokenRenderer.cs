using Serilog.Events;
using Serilog.Parsing;
using Serilog.Sinks.Avalonia.Browser.Rendering;

namespace Serilog.Sinks.Avalonia.Browser.Output;

internal class TimestampTokenRenderer(
    PropertyToken token,
    IFormatProvider? formatProvider) : OutputTemplateTokenRenderer
{
    public override void Render(LogEvent logEvent,
                                TokenEmitter emitToken)
    {
        // We need access to ScalarValue.Render() to avoid this alloc; just ensures
        // that custom format providers are supported properly.
        var sv = new ScalarValue(logEvent.Timestamp);
        var buffer = new StringWriter();
        sv.Render(buffer, token.Format, formatProvider);
        var str = buffer.ToString();

        emitToken(token.Alignment is not null
            ? Padding.Apply(str, token.Alignment)
            : str);
    }
}
