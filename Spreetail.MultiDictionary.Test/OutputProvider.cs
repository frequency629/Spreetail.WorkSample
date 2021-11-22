using System.Text;

namespace Spreetail.MultiDictionary.Test;

internal class OutputProvider
{
    private readonly StringBuilder output;

    public string Output => output.ToString().Trim();

    public OutputProvider()
    {
        output = new StringBuilder();
    }

    public void Write(string? value) =>
        output.AppendLine(value);

    public void ClearOutput() => output.Clear();
}