namespace Spreetail.MultiDictionary;

public class CommandParser
{
    private readonly Func<string?> inputProvider;

    public CommandParser(Func<string?> inputProvider)
    {
        this.inputProvider = inputProvider;
    }

    public ParsedCommand Parse()
    {
        var commandString = inputProvider() ?? string.Empty;
        var commandStrings = commandString.Split(" ");

        return new ParsedCommand(
            commandStrings[0],
            GetKeyFromCommandString(commandStrings),
            GetKValueFromCommandString(commandStrings)
        );
    }

    private static string GetKeyFromCommandString(IReadOnlyList<string> commandStrings) =>
        commandStrings.Count > 1
            ? commandStrings[1]
            : string.Empty;

    private static string GetKValueFromCommandString(IReadOnlyList<string> commandStrings) =>
        commandStrings.Count > 2
            ? commandStrings[2]
            : string.Empty;
}