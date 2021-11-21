using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

public class MembersCommandTest
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

        var output = new List<string>();

        var outputProvider = new Action<string?>(s =>
        {
            output.Add(s ?? string.Empty);
        });

        new MembersCommand(
                mvd,
                outputProvider
            )
            .Do(key);

        output.Should()
            .BeEquivalentTo(new List<string>
            {
                $"1) {value1}",
                $"2) {value2}",
            });
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