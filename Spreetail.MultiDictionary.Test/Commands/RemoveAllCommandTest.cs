using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

internal class RemoveAllCommandTest : BaseCommandTest
{
    [Test]
    public void Do_GivenKey_RemovesFromDictionary()
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

        new RemoveAllCommand(
                mvd,
                outputProvider.Write
            )
            .Do(key);

        mvd.Should()
            .NotContainKey(key);
    }

    [Test]
    public void Do_GivenKeyThatDoesNotExist_ThrowsError()
    {
        const string key = "foo";

        var mvd = new Dictionary<string, List<string>>();

        new Action(() =>
                new RemoveAllCommand(
                        mvd,
                        outputProvider.Write
                    )
                    .Do(key)
            )
            .Should()
            .ThrowExactly<Exception>();
    }
}