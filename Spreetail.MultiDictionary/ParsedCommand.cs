namespace Spreetail.MultiDictionary;

public class ParsedCommand
{
    public ParsedCommand(
        string action, 
        string key, 
        string value
    )
    {
        Action = action;
        Key = key;
        Value = value;
    }

    public string Action { get; }
    public string Key { get;  }
    public string Value { get; }

    public bool IsObjectCommand => 
        !string.IsNullOrEmpty(Action) && 
        string.IsNullOrEmpty(Key) && 
        string.IsNullOrEmpty(Value);

    public bool IsKeyCommand => 
        !string.IsNullOrEmpty(Action) && 
        !string.IsNullOrEmpty(Key) && 
        string.IsNullOrEmpty(Value);

    public bool IsValueCommand => 
        !string.IsNullOrEmpty(Action) && 
        !string.IsNullOrEmpty(Key) && 
        !string.IsNullOrEmpty(Value);

}
