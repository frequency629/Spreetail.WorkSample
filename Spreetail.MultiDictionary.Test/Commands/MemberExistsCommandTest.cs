using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

internal class MemberExistsCommandTest : BaseCommandTest
{

    [Test]
    public void Do_GivenExistingKeyAndExistingValue_OutputsTrue()
    {
        const string key = "foo";
        const string value = "bar";

        var mvd = new Dictionary<string, List<string>>
        {
            { key, new List<string>{ value } }
        };

        new MemberExistsCommand(mvd, outputProvider.Write)
            .Do(key, value);

        outputProvider.Output.Should().BeEquivalentTo("true");
    }

    [Test]
    public void Do_GivenExistingKeyAndNonExistingValue_OutputsFalse()
    {
        const string key = "foo";
        const string value = "bar";

        var mvd = new Dictionary<string, List<string>>();

        new MemberExistsCommand(mvd, outputProvider.Write)
            .Do(key, value);

        outputProvider.Output.Should().BeEquivalentTo("false");
    }

    [Test]
    public void Do_GivenNonExistingKey_OutputsFalse()
    {
        const string key = "foo";
        const string value = "bar";

        var mvd = new Dictionary<string, List<string>>();

        new MemberExistsCommand(mvd, outputProvider.Write)
            .Do(key, value);

        outputProvider.Output.Should().BeEquivalentTo("false");
    }
}