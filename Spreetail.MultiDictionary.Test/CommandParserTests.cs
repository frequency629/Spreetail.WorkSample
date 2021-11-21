using FluentAssertions;
using NUnit.Framework;

namespace Spreetail.MultiDictionary.Test;

public class CommandParserTests
{
    [Test]
    public void Parse_GivenCommandStringWithOnlyAction_ReturnsCommand()
    {
        const string action = "myAction";

        new CommandParser()
            .Parse(() => action)
            .Should()
            .BeEquivalentTo(
                new Command(
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

        new CommandParser()
            .Parse(() => $"{action} {key}")
            .Should()
            .BeEquivalentTo(
                new Command(
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

        new CommandParser()
            .Parse(() => $"{action} {key} {value}")
            .Should()
            .BeEquivalentTo(
                new Command(
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
        new CommandParser()
            .Parse(() => commandString)
            .Should()
            .BeEquivalentTo(
                new Command(
                    string.Empty,
                    string.Empty,
                    string.Empty
                )
            );

    }
}