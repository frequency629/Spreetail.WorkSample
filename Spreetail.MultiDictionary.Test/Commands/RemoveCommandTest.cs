using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

internal class RemoveCommandTest : BaseCommandTest
{
    [Test]
    public void Do_GivenValueInKeyWithMultipleValues_RemovesValueLeavesKey()
    {
        const string key = "foo";
        const string value1 = "bar";
        const string value2 = "baz";

        var mvd = new Dictionary<string, List<string>>
        {
            {
                key, new List<string>
                {
                    value1,
                    value2
                }
            }
        };

        new RemoveCommand(
                mvd,
                outputProvider.Write
            )
            .Do(
                key,
                value1
            );

        mvd.Should()
            .ContainKey(key);

        mvd[key].Should()
            .BeEquivalentTo(new List<string>
            {
                value2
            });
    }

    [Test]
    public void Do_GivenValueInKeyWithSingleValue_RemoveEntireKey()
    {
        const string key = "foo";
        const string value = "bar";

        var mvd = new Dictionary<string, List<string>>
        {
            {
                key, new List<string>
                {
                    value
                }
            },
        };

        new RemoveCommand(
                mvd,
                outputProvider.Write
            )
            .Do(
                key,
                value

            );

        mvd.Should()
            .NotContainKey(key);
    }

    [Test]
    public void Do_GivenKeyThatDoesNotExist_ThrowsError()
    {
        const string key = "foo";
        const string value = "bar";
        var mvd = new Dictionary<string, List<string>>();

        new Action(() =>
                new RemoveCommand(
                        mvd,
                        outputProvider.Write
                    )
                    .Do(
                        key,
                        value
                    )
            )
            .Should()
            .ThrowExactly<Exception>();
    }

    [Test]
    public void Do_GivenValueThatDoesNotExist_ThrowsError()
    {
        const string key = "foo";
        const string value = "bar";

        var mvd = new Dictionary<string, List<string>>
        {
            { key, new List<string>() }
        };

        new Action(() =>
                new RemoveCommand(
                        mvd,
                        outputProvider.Write
                    )
                    .Do(
                        key,
                        value
                    )
            )
            .Should()
            .ThrowExactly<Exception>();
    }
}