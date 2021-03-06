namespace Spreetail.MultiDictionary.Commands;

internal class KeysCommand
{
    public const string CommandText = "Keys";


    private readonly Dictionary<string, List<string>> dictionary;
    private readonly Action<string> outputProvider;

    public KeysCommand(
        Dictionary<string, List<string>> dictionary,
        Action<string?> outputProvider
    )
    {
        this.dictionary = dictionary;
        this.outputProvider = outputProvider;
    }

    public void Do()
    {
        var index = 0;
        foreach (var key in dictionary.Keys)
        {
            outputProvider($"{++index}) {key}");
        }
    }
}