namespace Spreetail.MultiDictionary;

public class Command
{
    public Command(
        string action, 
        string key, 
        string value
    )
    {
        Action = action;
        Key = key;
        Value = value;
    }

    public string Action { get; init; }
    public string Key { get; init; }
    public string Value { get; init; }
}