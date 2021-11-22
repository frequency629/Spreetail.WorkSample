namespace Spreetail.MultiDictionary.Commands;

internal class RemoveAllCommand
{
    public const string CommandText = "RemoveAll";
    
    private readonly Dictionary<string, List<string>> dictionary;
    private readonly Action<string> outputProvider;

    public RemoveAllCommand(
        Dictionary<string, List<string>> dictionary,
        Action<string> outputProvider
    )
    {
        this.dictionary = dictionary;
        this.outputProvider = outputProvider;
    }

    public void Do(string key)
    {
        if (KeyNotFound(key))
        {
            throw new Exception("Key does not exist");
        }

        dictionary.Remove(key);

        outputProvider("Removed");
    }

    private bool KeyNotFound(string key) =>
        !dictionary.ContainsKey(key);
}