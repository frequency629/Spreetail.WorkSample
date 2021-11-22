namespace Spreetail.MultiDictionary.Commands;

internal class MemberExistsCommand
{
    private readonly Dictionary<string, List<string>> dictionary;
    private readonly Action<string> outputProvider;

    public MemberExistsCommand(
        Dictionary<string, List<string>> dictionary,
        Action<string> outputProvider
    )
    {
        this.dictionary = dictionary;
        this.outputProvider = outputProvider;
    }

    public void Do(string key, string value) =>
        outputProvider(
            (
                dictionary.ContainsKey(key) && 
                dictionary[key].Contains(value)
            ).ToString()
        );
}