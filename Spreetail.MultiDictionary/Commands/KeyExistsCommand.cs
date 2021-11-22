namespace Spreetail.MultiDictionary.Commands;

internal class KeyExistsCommand
{
    public const string CommandText = "KeyExists";


    private readonly Dictionary<string, List<string>> dictionary;
    private readonly Action<string> outputProvider;

    public KeyExistsCommand(
        Dictionary<string, List<string>> dictionary,
        Action<string> outputProvider
    )
    {
        this.dictionary = dictionary;
        this.outputProvider = outputProvider;
    }

    public void Do(string key) => 
        outputProvider(dictionary.ContainsKey(key).ToString());
}