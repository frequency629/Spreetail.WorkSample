namespace Spreetail.MultiDictionary.Commands;

internal class ItemsCommand
{
    public const string CommandText = "Items";


    private readonly Dictionary<string, List<string>> dictionary;
    private readonly Action<string> outputProvider;

    public ItemsCommand(
        Dictionary<string, List<string>> dictionary,
        Action<string> outputProvider
    )
    {
        this.dictionary = dictionary;
        this.outputProvider = outputProvider;
    }

    public void Do()
    {
        foreach (var key in dictionary.Keys)
        {
            foreach (var value in dictionary[key])
            {
                outputProvider($"{key}: {value}");
            }
        }
    }
}