using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Commands;

namespace Spreetail.MultiDictionary.Test.Commands;

internal class KeysCommandTest
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

        var output = new List<string>();

        var outputProvider = new Action<string?>(s =>
        {
            output.Add(s ?? string.Empty);
        });

        new KeysCommand(mvd, outputProvider)
            .Do();

        output.Should()
            .BeEquivalentTo(new List<string>
            {
                $"1) {key1}",
                $"2) {key2}",
            });
    }

    [Test]
    public void Do_GivenEmptyWithKeys_NoOutput()
    {
        var mvd = new Dictionary<string, List<string>>();

        var output = new List<string>();

        var outputProvider = new Action<string?>(s =>
        {
            output.Add(s ?? string.Empty);
        });

        new KeysCommand(mvd, outputProvider)
            .Do();

        output.Should().BeEmpty();
    }
}