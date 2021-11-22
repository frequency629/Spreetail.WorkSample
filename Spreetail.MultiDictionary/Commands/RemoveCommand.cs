namespace Spreetail.MultiDictionary.Commands;

internal class RemoveCommand
{
    public const string CommandText = "Remove";
    
    private readonly Dictionary<string, List<string>> dictionary;

    public RemoveCommand(
        Dictionary<string, List<string>> dictionary
    )
    {
        this.dictionary = dictionary;
    }

    public void Do(string key, string value)
    {
        if (KeyNotFound(key))
        {
            throw new Exception("Key does not exist");
        }

        if(ValueNotFound(key, value))
        {
            throw new Exception("Value does not exist");
        }

        dictionary[key].Remove(value);

        if (KeyContainsNoValues(key))
        {
            dictionary.Remove(key);
        }
    }

    private bool KeyContainsNoValues(string key) => !dictionary[key].Any();

    private bool ValueNotFound(string key, string value) => 
        !dictionary[key].Contains(value);

    private bool KeyNotFound(string key) => 
        !dictionary.ContainsKey(key);
        
}