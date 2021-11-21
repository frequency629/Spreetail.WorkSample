namespace Spreetail.MultiDictionary;

public class AddCommand
{
    private readonly MultiValueDictionary dictionary;

    public AddCommand(
        MultiValueDictionary dictionary
    )
    {
        this.dictionary = dictionary;
    }

    public void Do(Command command)
    {
        if (IsNewKey(command.Key))
        {
            dictionary.Add(command.Key, new List<string>());
        }

        if (IsDuplicateValue(command))
        {
            throw new Exception("Member already exists for key");
        }

        dictionary[command.Key]
            .Add(command.Value);
    }

    private bool IsDuplicateValue(Command command) =>
        dictionary[command.Key].Contains(command.Value);

    private bool IsNewKey(string key) => 
        !dictionary.ContainsKey(key);
}