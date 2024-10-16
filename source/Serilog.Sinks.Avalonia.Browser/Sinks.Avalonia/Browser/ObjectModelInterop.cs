using Serilog.Events;

namespace Serilog.Sinks.Avalonia.Browser;

internal static class ObjectModelInterop
{
    /// <summary>
    ///     Convert a Serilog <see cref="LogEventPropertyValue" /> for JavaScript interop.
    /// </summary>
    public static object? ToInteropValue(LogEventPropertyValue value,
                                         string? format = null)
    {
        switch (value)
        {
            case ScalarValue sv when format == null:
                return sv.Value;

            case ScalarValue sv:
                var sw = new StringWriter();
                sv.Render(sw, format);
                return sw.ToString();

            case SequenceValue sqv:
                return sqv.Elements
                    .Select(e => ToInteropValue(e))
                    .ToArray();

            case StructureValue st:
                return st.Properties
                    .ToDictionary(kv => kv.Name, kv => ToInteropValue(kv.Value));

            case DictionaryValue dv:
                return dv.Elements
                    // May generate a runtime exception if the key is null, but this is very unusual in .NET because
                    // the original dictionary that was serialized most likely was of a type without null keys. We
                    // might still do better than this in the future.
                    .ToDictionary(kv => ToInteropValue(kv.Key)!, kv => ToInteropValue(kv.Value));

            default:
                return value;
        }
    }
}
