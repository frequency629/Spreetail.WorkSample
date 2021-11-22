using NUnit.Framework;

namespace Spreetail.MultiDictionary.Test;

internal class ParsedCommandTest
{
    [TestCase("Action", "", "", ExpectedResult = true)]
    [TestCase("Action", "Key", "", ExpectedResult = false)]
    [TestCase("Action", "Key", "Value", ExpectedResult = false)]
    public bool IsObjectCommand_GivenCommand_ReturnsExpectedResult(string action, string key, string value) =>
        new ParsedCommand(action, key, value).IsObjectCommand;

    [TestCase("Action", "", "", ExpectedResult = false)]
    [TestCase("Action", "Key", "", ExpectedResult = true)]
    [TestCase("Action", "Key", "Value", ExpectedResult = false)]
    public bool IsKeyCommand_GivenCommand_ReturnsExpectedResult(string action, string key, string value) =>
        new ParsedCommand(action, key, value).IsKeyCommand;

    [TestCase("Action", "", "", ExpectedResult = false)]
    [TestCase("Action", "Key", "", ExpectedResult = false)]
    [TestCase("Action", "Key", "Value", ExpectedResult = true)]
    public bool IsValueCommand_GivenCommand_ReturnsExpectedResult(string action, string key, string value) =>
        new ParsedCommand(action, key, value).IsValueCommand;
}