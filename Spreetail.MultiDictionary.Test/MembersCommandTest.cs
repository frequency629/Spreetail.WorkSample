using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Spreetail.MultiDictionary.Test;

public class MembersCommandTest
{
    [Test]
    public void Do_GivenExistingKey_OutputsValues()
    {
        const string key = "foo";
        const string value1 = "bar";
        const string value2 = "baz";

        var mvd = new MultiValueDictionary
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

        var outputProvider = new Action<string>(s =>
        {
            output.Add(s);
        });

        new MembersCommand(
                mvd,
                outputProvider
            )
            .Do(
                new Command(
                    string.Empty,
                    key,
                    string.Empty
                )
            );

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

        var mvd = new MultiValueDictionary();

        new Action(() =>
                new MembersCommand(
                        mvd,
                        _ => {}
                    )
                    .Do(
                        new Command(
                            string.Empty,
                            key,
                            string.Empty
                        )
                    )
            )
            .Should()
            .ThrowExactly<Exception>();

    }
}