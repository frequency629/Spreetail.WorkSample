namespace Spreetail.MultiDictionary.Commands;

internal class RemoveAllCommand
{
    public const string CommandText = "RemoveAll";


    private readonly Dictionary<string, List<string>> dictionary;

    public RemoveAllCommand(
        Dictionary<string, List<string>> dictionary
    )
    {
        this.dictionary = dictionary;
    }

    public void Do(string key)
    {
        if (KeyNotFound(key))
        {
            throw new Exception("Key does not exist");
        }

        dictionary.Remove(key);
    }

    private bool KeyNotFound(string key) =>
        !dictionary.ContainsKey(key);
}