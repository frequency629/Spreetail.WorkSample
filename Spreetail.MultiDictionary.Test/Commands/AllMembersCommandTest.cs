using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

internal class AllMembersCommandTest
{
    private TestableOutputProvider outputProvider = null!;

    [SetUp]
    public void SetUp()
    {
        outputProvider = new TestableOutputProvider();
    }

    [Test]
    public void Do_GivenSingleKeyDictionary_OutputsAllValues()
    {
        const string key = "foo";
        const string value1 = "bar";
        const string value2 = "baz";

        var mvd = new Dictionary<string, List<string>>
        {
            { key, new List<string>{ value1, value2 } }
        };

        new AllMembersCommand(mvd, outputProvider.Write)
            .Do();

        outputProvider.Output.Should().BeEquivalentTo($"bar{Environment.NewLine}baz");
    }

    [Test]
    public void Do_GivenMultiKeyDictionary_OutputsAllValues()
    {
        const string key1= "foo";
        const string key2= "bang";
        const string value1 = "bar";
        const string value2 = "baz";

        var mvd = new Dictionary<string, List<string>>
        {
            { key1, new List<string>{ value1, value2 } },
            { key2, new List<string>{ value1, value2 } },
        };

        new AllMembersCommand(mvd, outputProvider.Write)
            .Do();

        outputProvider.Output.Should().BeEquivalentTo($"bar{Environment.NewLine}baz{Environment.NewLine}bar{Environment.NewLine}baz");
    }

    [Test]
    public void Do_GivenEmptyDictionary_OutputsNothing()
    {

        var mvd = new Dictionary<string, List<string>>();

        new AllMembersCommand(mvd, outputProvider.Write)
            .Do();

        outputProvider.Output.Should().BeEquivalentTo(string.Empty);
    }
}