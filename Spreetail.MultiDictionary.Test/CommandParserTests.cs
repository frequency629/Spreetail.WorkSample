using FluentAssertions;
using NUnit.Framework;

namespace Spreetail.MultiDictionary.Test;

public class CommandParserTests
{
    [Test]
    public void Parse_GivenCommandStringWithOnlyAction_ReturnsCommand()
    {
        const string action = "myAction";

        new CommandParser(() => action)
            .Parse()
            .Should()
            .BeEquivalentTo(
                new ParsedCommand(
                    action,
                    string.Empty,
                    string.Empty
                )
            );
    }

    [Test]
    public void Parse_GivenCommandStringWithActionAndKey_ReturnsCommand()
    {
        const string action = "myAction";
        const string key = "myKey";

        new CommandParser(() => $"{action} {key}")
            .Parse()
            .Should()
            .BeEquivalentTo(
                new ParsedCommand(
                    action,
                    key,
                    string.Empty
                )
            );
    }

    [Test]
    public void Parse_GivenCommandStringWithActionAndKeyAndValue_ReturnsCommand()
    {
        const string action = "myAction";
        const string key = "myKey";
        const string value = "myValue";

        new CommandParser(() => $"{action} {key} {value}")
            .Parse()
            .Should()
            .BeEquivalentTo(
                new ParsedCommand(
                    action,
                    key,
                    value
                )
            );
    }

    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void Parse_GivenInvalidCommandString_ReturnsEmptyCommand(string commandString)
    {
        new CommandParser(() => commandString)
            .Parse()
            .Should()
            .BeEquivalentTo(
                new ParsedCommand(
                    string.Empty,
                    string.Empty,
                    string.Empty
                )
            );

    }


}