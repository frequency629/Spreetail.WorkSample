using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

public class AddCommandTest
{
    [Test]
    public void Do_GivenNewKey_AddValueToDictionary()
    {
        const string key = "foo";
        const string value = "bar";

        var mvd = new Dictionary<string, List<string>>();

        new AddCommand(mvd)
            .Do(
                key,
                value
            );

        mvd.Should()
            .ContainKey(key);

        mvd[key].Should()
            .BeEquivalentTo(new List<string>
            {
                value
            });
    }

    [Test]
    public void Do_GivenExistingKey_AddValueToDictionary()
    {
        const string key = "foo";
        const string value1 = "bar";
        const string value2 = "baz";

        var mvd = new Dictionary<string, List<string>>
        {
            {
                key, new List<string>
                {
                    value1
                }
            },
        };

        new AddCommand(mvd)
            .Do(
                key,
                value2

            );

        mvd.Should()
            .ContainKey(key);

        mvd[key].Should()
            .BeEquivalentTo(new List<string>
            {
                value1,
                value2
            });
    }

    [Test]
    public void Do_GivenDuplicateValueForKey_ThrowsError()
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
            }
        };
        new Action(() =>
                new AddCommand(mvd)
                    .Do(
                        key,
                        value
                    )
            )
            .Should()
            .ThrowExactly<Exception>();

    }
}