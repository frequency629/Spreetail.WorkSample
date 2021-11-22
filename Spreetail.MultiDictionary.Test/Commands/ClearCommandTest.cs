using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

internal class ClearCommandTest : BaseCommandTest
{
    [Test]
    public void Do_GivenDictionary_RemovesAllKeys()
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

        new ClearCommand(
                mvd,
                outputProvider.Write
            )
            .Do();

        mvd.Should().BeEmpty();
    }
}