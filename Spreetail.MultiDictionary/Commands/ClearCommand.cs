namespace Spreetail.MultiDictionary.Commands;

internal class ClearCommand
{
    public const string CommandText = "Clear";
    
    private readonly Dictionary<string, List<string>> dictionary;
    private readonly Action<string> outputProvider;

    public ClearCommand(
        Dictionary<string, List<string>> dictionary,
        Action<string> outputProvider
    )
    {
        this.dictionary = dictionary;
        this.outputProvider = outputProvider;
    }

    public void Do()
    {
        dictionary.Clear();
        outputProvider("Cleared");
    }
}