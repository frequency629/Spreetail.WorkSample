namespace Spreetail.MultiDictionary.Commands;

internal class AddCommand
{
    public const string CommandText = "Add";

    private readonly Dictionary<string, List<string>> dictionary;

    public AddCommand(
        Dictionary<string, List<string>> dictionary
    )
    {
        this.dictionary = dictionary;
    }

    public void Do(string key, string value)
    {
        if (IsNewKey(key))
        {
            dictionary.Add(key, new List<string>());
        }

        if (IsDuplicateValue(key, value))
        {
            throw new Exception("Value already exists for key");
        }

        dictionary[key]
            .Add(value);
    }

    private bool IsDuplicateValue(string key, string value) =>
        dictionary[key].Contains(value);

    private bool IsNewKey(string key) => 
        !dictionary.ContainsKey(key);
}