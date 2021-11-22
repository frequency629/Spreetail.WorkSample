using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

internal class KeysCommandTest : BaseCommandTest
{
    [Test]
    public void Do_GivenDictionaryWithKeys_OutputKeys()
    {
        const string key1 = "foo";
        const string key2 = "baz";

        var mvd = new Dictionary<string, List<string>>
        {
            {
                key1,
                new List<string>()
            },
            {
                key2,
                new List<string>()
            },
        };
        

        new KeysCommand(mvd, outputProvider.Write)
            .Do();

        outputProvider.Output
            .Should()
            .BeEquivalentTo($"1) {key1}{Environment.NewLine}2) {key2}");
    }

    [Test]
    public void Do_GivenEmptyWithKeys_NoOutput()
    {
        var mvd = new Dictionary<string, List<string>>();
        
        new KeysCommand(mvd, outputProvider.Write)
            .Do();

        outputProvider.Output.Should().BeEquivalentTo(string.Empty);
    }
}