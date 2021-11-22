namespace Spreetail.MultiDictionary.Commands;

internal class MembersCommand
{
    private readonly Dictionary<string, List<string>> dictionary;
    private readonly Action<string> outputProvider;

    public MembersCommand(
        Dictionary<string, List<string>> dictionary,
        Action<string?> outputProvider
    )
    {
        this.dictionary = dictionary;
        this.outputProvider = outputProvider;
    }

    public void Do(string key)
    {
        if (KeyDoesNotExist(key))
        {
            throw new Exception("Key does not exist");
        }

        var index = 0;
        foreach (var value in dictionary[key])
        {
            outputProvider($"{++index}) {value}");
        }
    }

    private bool KeyDoesNotExist(string key) =>
        !dictionary.ContainsKey(key);
}