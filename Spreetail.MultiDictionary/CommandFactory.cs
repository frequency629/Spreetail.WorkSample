using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary;

public class CommandFactory
{
    private readonly CommandParser commandParser;
    private readonly Dictionary<string, Action<string, string>> valueCommands;
    private readonly Dictionary<string, Action<string>> keyCommands;
    private readonly Dictionary<string, Action> objectCommands;

    public CommandFactory(
        Dictionary<string, List<string>> dictionary,
        Action<string?> outputProvider,
        CommandParser commandParser
    )
    {
        this.commandParser = commandParser;
        valueCommands = new Dictionary<string, Action<string, string>>(StringComparer.OrdinalIgnoreCase)
        {
            { "Add", (key, member) => new AddCommand(dictionary).Do(key, member) }
        };

        keyCommands = new Dictionary<string, Action<string>>(StringComparer.OrdinalIgnoreCase)
        {
            { "Members", (key) => new MembersCommand(dictionary, outputProvider).Do(key) }
        };

        objectCommands = new Dictionary<string, Action>(StringComparer.OrdinalIgnoreCase)
        {
            { "Keys", () => new KeysCommand(dictionary, outputProvider).Do() }
        };
    }

    public Action Get()
    {
        var parsedCommand = commandParser.Parse();

        return parsedCommand switch
        {
            _ when ParsedCommandIsObjectCommand(parsedCommand) =>
                () => objectCommands[parsedCommand.Action](),

            _ when ParsedCommandIsKeyCommand(parsedCommand) =>
                () => keyCommands[parsedCommand.Action](parsedCommand.Key),

            _ when ParsedCommandIsValueCommand(parsedCommand) =>
                () => valueCommands[parsedCommand.Action](parsedCommand.Key, parsedCommand.Value),

            _ => throw new Exception("Unsupported command")
        };
    }

    private bool ParsedCommandIsObjectCommand(ParsedCommand parsedCommand) => 
        parsedCommand.IsObjectCommand && objectCommands.ContainsKey(parsedCommand.Action);

    private bool ParsedCommandIsKeyCommand(ParsedCommand parsedCommand) => 
        parsedCommand.IsKeyCommand && keyCommands.ContainsKey(parsedCommand.Action);

    private bool ParsedCommandIsValueCommand(ParsedCommand parsedCommand) => 
        parsedCommand.IsValueCommand && valueCommands.ContainsKey(parsedCommand.Action);
}