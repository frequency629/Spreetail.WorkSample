using System.Text;

namespace Spreetail.MultiDictionary.Test;

internal class TestableOutputProvider
{
    private readonly StringBuilder output;

    public string Output => output.ToString().Trim();

    public TestableOutputProvider()
    {
        output = new StringBuilder();
    }
    
    public void Write(string value) => 
        output.AppendLine(value);
}