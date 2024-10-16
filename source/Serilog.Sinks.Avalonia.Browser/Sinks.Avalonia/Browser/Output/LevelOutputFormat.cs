using Serilog.Events;
using Serilog.Sinks.Avalonia.Browser.Rendering;

// ReSharper disable StringLiteralTypo

namespace Serilog.Sinks.Avalonia.Browser.Output;

/// <summary>
///     Implements the {Level} element.
///     can now have a fixed width applied to it, as well as casing rules.
///     Width is set through formats like "u3" (uppercase three chars),
///     "w1" (one lowercase char), or "t4" (title case four chars).
/// </summary>
internal static class LevelOutputFormat
{
    private static readonly string[][] TitleCaseLevelMap =
    [
        ["V", "Vb", "Vrb", "Verb"],
        ["D", "De", "Dbg", "Dbug"],
        ["I", "In", "Inf", "Info"],
        ["W", "Wn", "Wrn", "Warn"],
        ["E", "Er", "Err", "Eror"],
        ["F", "Fa", "Ftl", "Fatl"]
    ];

    private static readonly string[][] LowercaseLevelMap =
    [
        ["v", "vb", "vrb", "verb"],
        ["d", "de", "dbg", "dbug"],
        ["i", "in", "inf", "info"],
        ["w", "wn", "wrn", "warn"],
        ["e", "er", "err", "eror"],
        ["f", "fa", "ftl", "fatl"]
    ];

    private static readonly string[][] UppercaseLevelMap =
    [
        ["V", "VB", "VRB", "VERB"],
        ["D", "DE", "DBG", "DBUG"],
        ["I", "IN", "INF", "INFO"],
        ["W", "WN", "WRN", "WARN"],
        ["E", "ER", "ERR", "EROR"],
        ["F", "FA", "FTL", "FATL"]
    ];

    public static string GetLevelMoniker(LogEventLevel value,
                                         string? format = null)
    {
        if (format is null || (format.Length != 2 && format.Length != 3))
            return Casing.Format(value.ToString(), format);

        // Using int.Parse() here requires allocating a string to exclude the first character prefix.
        // Junk like "wxy" will be accepted but produce benign results.
        var width = format[1] - '0';
        if (format.Length == 3)
        {
            width *= 10;
            width += format[2] - '0';
        }

        switch (width)
        {
            case < 1:
                return string.Empty;
            case > 4:
            {
                var stringValue = value.ToString();
                if (stringValue.Length > width)
                    stringValue = stringValue.Substring(0, width);
                return Casing.Format(stringValue);
            }
        }

        var index = (int)value;
        if (index is >= 0 and <= (int)LogEventLevel.Fatal)
            switch (format[0])
            {
                case 'w':
                    return LowercaseLevelMap[index][width - 1];
                case 'u':
                    return UppercaseLevelMap[index][width - 1];
                case 't':
                    return TitleCaseLevelMap[index][width - 1];
            }

        return Casing.Format(value.ToString(), format);
    }
}
