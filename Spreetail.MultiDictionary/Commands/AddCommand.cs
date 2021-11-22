namespace Spreetail.MultiDictionary.Commands;

internal class AddCommand
{
    public const string CommandText = "Add";

    private readonly Dictionary<string, List<string>> dictionary;
    private readonly Action<string> outputProvider;

    public AddCommand(
        Dictionary<string, List<string>> dictionary,
        Action<string> outputProvider
    )
    {
        this.dictionary = dictionary;
        this.outputProvider = outputProvider;
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

        outputProvider("Added");
    }

    private bool IsDuplicateValue(string key, string value) =>
        dictionary[key].Contains(value);

    private bool IsNewKey(string key) => 
        !dictionary.ContainsKey(key);
}