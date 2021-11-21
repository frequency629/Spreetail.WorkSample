namespace Spreetail.MultiDictionary;


public class MultiValueDictionary
{
    private readonly Dictionary<string, List<string>> dictionary = new();
    
    private readonly CommandFactory commandFactory;

    public MultiValueDictionary(
        Func<string?> inputProvider,
        Action<string?> outputProvider
    )
    {
        this.commandFactory = new CommandFactory(
            dictionary, 
            outputProvider,
            new CommandParser(inputProvider)
        );
    }
    

    public void DoCommand()
    {
        var command = commandFactory.Get();

        command();
    }
}