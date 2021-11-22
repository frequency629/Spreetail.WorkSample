using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

internal class KeyExistsCommandTest
{
    private TestableOutputProvider outputProvider = null!;

    [SetUp]
    public void SetUp()
    {
        outputProvider = new TestableOutputProvider();
    }

    [Test]
    public void Do_GivenAnExistingKey_OutputsTrue()
    {
        const string key = "foo";

        var mvd = new Dictionary<string, List<string>>
        {
            { key, new List<string>() }
        };

        new KeyExistsCommand(mvd, outputProvider.Write)
            .Do(key);

        outputProvider.Output.Should().BeEquivalentTo("true");
    }

    [Test]
    public void Do_GivenAnExistingKey_OutputsFalse()
    {
        const string key = "foo";

        var mvd = new Dictionary<string, List<string>>();

        new KeyExistsCommand(mvd, outputProvider.Write)
            .Do(key);

        outputProvider.Output.Should().BeEquivalentTo("false");
    }
}