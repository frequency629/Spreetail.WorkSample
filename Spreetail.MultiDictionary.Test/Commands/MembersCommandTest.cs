using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

internal class MembersCommandTest : BaseCommandTest
{
    [Test]
    public void Do_GivenExistingKey_OutputsValues()
    {
        const string key = "foo";
        const string value1 = "bar";
        const string value2 = "baz";

        var mvd = new Dictionary<string, List<string>>
        {
            {
                key,
                new List<string>
                {
                    value1,
                    value2
                }
            }
        };
        

        new MembersCommand(
                mvd,
                outputProvider.Write
            )
            .Do(key);

        outputProvider.Output
            .Should()
            .BeEquivalentTo($"1) {value1}{Environment.NewLine}2) {value2}");
    }

    [Test]
    public void Do_GivenNonExistingKey_ThrowsError()
    {
        const string key = "foo";

        var mvd = new Dictionary<string, List<string>>();

        new Action(() =>
                new MembersCommand(
                        mvd,
                        _ => {}
                    )
                    .Do(key)
            )
            .Should()
            .ThrowExactly<Exception>();

    }
}