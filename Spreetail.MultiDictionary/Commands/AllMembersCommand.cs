namespace Spreetail.MultiDictionary.Commands;

internal class AllMembersCommand
{
    private readonly Dictionary<string, List<string>> dictionary;
    private readonly Action<string> outputProvider;

    public AllMembersCommand(
        Dictionary<string, List<string>> dictionary,
        Action<string> outputProvider
    )
    {
        this.dictionary = dictionary;
        this.outputProvider = outputProvider;
    }

    public void Do()
    {
        foreach (var list in dictionary.Values)
        {
            foreach (var value in list)
            {
                outputProvider(value);
            }
        }
    }
}