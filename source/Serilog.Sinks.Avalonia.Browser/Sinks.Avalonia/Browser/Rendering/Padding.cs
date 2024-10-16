using System.Text;
using Serilog.Parsing;

namespace Serilog.Sinks.Avalonia.Browser.Rendering;

internal static class Padding
{
    /// <summary>
    /// Constructs the output string containing the provided value and
    /// applying direction-based padding when <paramref name="alignment"/> is provided.
    /// </summary>
    /// <param name="value">Provided value.</param>
    /// <param name="alignment">The alignment settings to apply when rendering <paramref name="value"/>.</param>
    /// <returns>string with value and applied padding</returns>
    public static string Apply(string value, Alignment? alignment)
    {
        if (alignment is null || value.Length >= alignment.Value.Width)
        {
            return value;
        }

        var sb = new StringBuilder();
        var pad = alignment.Value.Width - value.Length;

        if (alignment.Value.Direction == AlignmentDirection.Left)
            sb.Append(value);

        sb.Append(' ', pad);

        if (alignment.Value.Direction == AlignmentDirection.Right)
            sb.Append(value);
        return sb.ToString();
    }
}
