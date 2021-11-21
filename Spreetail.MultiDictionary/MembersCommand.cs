namespace Spreetail.MultiDictionary;

public class MembersCommand
{
    private readonly MultiValueDictionary dictionary;
    private readonly Action<string> outputProvider;

    public MembersCommand(
        MultiValueDictionary dictionary,
        Action<string> outputProvider
    )
    {
        this.dictionary = dictionary;
        this.outputProvider = outputProvider;
    }

    public void Do(Command command)
    {
        if (KeyDoesNotExist(command.Key))
        {
            throw new Exception("Key does not exist");
        }

        var index = 0;
        foreach (var value in dictionary[command.Key])
        {
            outputProvider($"{++index}) {value}");
        }
    }

    private bool KeyDoesNotExist(string key) =>
        !dictionary.ContainsKey(key);
}