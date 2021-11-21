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

    public string Action { get; }
    public string Key { get;  }
    public string Value { get; }
}
