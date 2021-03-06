using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

internal class ItemsCommandTest : BaseCommandTest
{
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

        new ItemsCommand(mvd, outputProvider.Write)
            .Do();

        outputProvider.Output
            .Should()
            .BeEquivalentTo(@$"1) {key}: {value1}{Environment.NewLine}2) {key}: {value2}");
    }

    [Test]
    public void Do_GivenMultiKeyDictionary_OutputsAllValues()
    {
        const string key1 = "foo";
        const string key2 = "bang";
        const string value1 = "bar";
        const string value2 = "baz";

        var mvd = new Dictionary<string, List<string>>
        {
            { key1, new List<string>{ value1, value2 } },
            { key2, new List<string>{ value1, value2 } },
        };

        new ItemsCommand(mvd, outputProvider.Write)
            .Do();

        outputProvider.Output
            .Should()
            .BeEquivalentTo($"1) {key1}: {value1}{Environment.NewLine}2) {key1}: {value2}{Environment.NewLine}3) {key2}: {value1}{Environment.NewLine}4) {key2}: {value2}");
    }

    [Test]
    public void Do_GivenEmptyDictionary_OutputsNothing()
    {

        var mvd = new Dictionary<string, List<string>>();

        new ItemsCommand(mvd, outputProvider.Write)
            .Do();

        outputProvider.Output.Should().BeEquivalentTo(string.Empty);
    }
}