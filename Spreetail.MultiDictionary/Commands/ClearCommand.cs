namespace Spreetail.MultiDictionary.Commands;

internal class ClearCommand
{
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