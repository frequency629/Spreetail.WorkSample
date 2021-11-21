using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Spreetail.MultiDictionary.Test;

public class KeysCommandTest
{
    [Test]
    public void Do_GivenDictionaryWithKeys_OutputKeys()
    {
        const string key1 = "foo";
        const string key2 = "baz";

        var mvd = new MultiValueDictionary
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

        var outputProvider = new Action<string>(s =>
        {
            output.Add(s);
        });

        new KeysCommand(mvd, outputProvider)
            .Do(
                new Command(
                    string.Empty,
                    string.Empty,
                    string.Empty
                )
            );

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
        var mvd = new MultiValueDictionary();

        var output = new List<string>();

        var outputProvider = new Action<string>(s =>
        {
            output.Add(s);
        });

        new KeysCommand(mvd, outputProvider)
            .Do(
                new Command(
                    string.Empty,
                    string.Empty,
                    string.Empty
                )
            );

        output.Should().BeEmpty();
    }
}