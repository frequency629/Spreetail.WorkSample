namespace Spreetail.MultiDictionary;

public class KeysCommand
{
    private readonly MultiValueDictionary dictionary;
    private readonly Action<string> outputProvider;

    public KeysCommand(
        MultiValueDictionary dictionary,
        Action<string> outputProvider
    )
    {
        this.dictionary = dictionary;
        this.outputProvider = outputProvider;
    }

    public void Do(Command command)
    {
        var index = 0;
        foreach (var key in dictionary.Keys)
        {
            outputProvider($"{++index}) {key}");
        }
    }
}