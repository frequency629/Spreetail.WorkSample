namespace Spreetail.MultiDictionary.Commands;

internal class ClearCommand
{
    public const string CommandText = "Clear";


    private readonly Dictionary<string, List<string>> dictionary;

    public ClearCommand(
        Dictionary<string, List<string>> dictionary
    )
    {
        this.dictionary = dictionary;
    }

    public void Do() => 
        dictionary.Clear();
}