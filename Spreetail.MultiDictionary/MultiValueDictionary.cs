namespace Spreetail.MultiDictionary;


public class MultiValueDictionary
{
    private readonly Action<string?> outputProvider;
    private readonly Dictionary<string, List<string>> dictionary = new();
    
    private readonly CommandFactory commandFactory;

    public MultiValueDictionary(
        Func<string?> inputProvider,
        Action<string?> outputProvider
    )
    {
        this.outputProvider = outputProvider;
        this.commandFactory = new CommandFactory(
            dictionary, 
            outputProvider,
            new CommandParser(inputProvider)
        );
    }
    

    public void DoCommand()
    {
        try
        {
            var command = commandFactory.Get();
            command();
        }
        catch (Exception ex)
        {
            outputProvider($"ERROR {ex.Message}");
        }
    }
}