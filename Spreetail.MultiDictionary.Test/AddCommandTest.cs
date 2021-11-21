using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Spreetail.MultiDictionary.Test;

public class AddCommandTest
{
    [Test]
    public void Do_GivenNewKey_AddValueToDictionary()
    {
        const string key = "foo";
        const string value = "bar";

        var mvd = new MultiValueDictionary();

        new AddCommand(mvd)
            .Do(
                new Command(
                    string.Empty,
                    key,
                    value
                )
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

        var mvd = new MultiValueDictionary();

        new AddCommand(mvd)
            .Do(
                new Command(
                    string.Empty,
                    key,
                    value1
                )
            );

        new AddCommand(mvd)
            .Do(
                new Command(
                    string.Empty,
                    key,
                    value2
                )
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

        var mvd = new MultiValueDictionary();

        new AddCommand(mvd)
            .Do(
                new Command(
                    string.Empty,
                    key,
                    value
                )
            );

        new Action(() =>
                new AddCommand(mvd)
                    .Do(
                        new Command(
                            string.Empty,
                            key,
                            value
                        )
                    )
            )
            .Should()
            .ThrowExactly<Exception>();

    }
}