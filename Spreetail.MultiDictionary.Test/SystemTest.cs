using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Spreetail.MultiDictionary.Test.Commands;

namespace Spreetail.MultiDictionary.Test
{
    internal class SystemTest : BaseCommandTest
    {
        private InputProvider input = null!;
        private MultiValueDictionary mvd = null!;
        private StringBuilder expectedOutput = null!;
        
        [SetUp]
        public void SetUp()
        {
            input = new InputProvider();
            mvd = new MultiValueDictionary(input.Read, outputProvider.Write);
            expectedOutput = new StringBuilder();
        }

        [Test]
        public void Keys()
        {
            RunCommand("add foo bar");
            expectedOutput.AppendLine("Added");

            RunCommand("add baz bang");
            expectedOutput.AppendLine("Added");

            RunCommand("keys");
            expectedOutput.AppendLine("1) foo");
            expectedOutput.AppendLine("2) baz");

            VerifyOutput();
        }

        [Test]
        public void Members()
        {
            RunCommand("add foo bar");
            expectedOutput.AppendLine("Added");

            RunCommand("add foo baz");
            expectedOutput.AppendLine("Added");

            RunCommand("members foo");
            expectedOutput.AppendLine("1) bar");
            expectedOutput.AppendLine("2) baz");

            RunCommand("members bad");
            expectedOutput.AppendLine("ERROR, key does not exist");

            VerifyOutput();
        }

        [Test]
        public void Add()
        {
            RunCommand("add foo bar");
            expectedOutput.AppendLine("Added");

            RunCommand("add foo baz");
            expectedOutput.AppendLine("Added");

            RunCommand("add foo bar");
            expectedOutput.AppendLine("ERROR, value already exists for key");

            VerifyOutput();
        }

        [Test]
        public void Remove()
        {
            RunCommand("add foo bar");
            expectedOutput.AppendLine("Added");

            RunCommand("add foo baz");
            expectedOutput.AppendLine("Added");

            RunCommand("remove foo bar");
            expectedOutput.AppendLine("Removed");

            RunCommand("remove foo bar");
            expectedOutput.AppendLine("ERROR, value does not exist");
            
            RunCommand("keys");
            expectedOutput.AppendLine("1) foo");

            RunCommand("remove foo baz");
            expectedOutput.AppendLine("removed");

            RunCommand("keys");
            RunCommand("remove boom pow");

            expectedOutput.AppendLine("ERROR, key does not exist");

            VerifyOutput();
        }

        [Test]
        public void RemoveAll()
        {
            RunCommand("add foo bar");
            expectedOutput.AppendLine("Added");

            RunCommand("add foo baz");
            expectedOutput.AppendLine("Added");

            RunCommand("keys");
            expectedOutput.AppendLine("1) foo");

            RunCommand("removeAll foo");
            expectedOutput.AppendLine("removed");

            RunCommand("keys");

            RunCommand("removeAll foo");
            expectedOutput.AppendLine("ERROR, key does not exist");

            VerifyOutput();
        }

        [Test]
        public void Clear()
        {
            RunCommand("add foo bar");
            expectedOutput.AppendLine("Added");

            RunCommand("add bang zip");
            expectedOutput.AppendLine("Added");

            RunCommand("keys");
            expectedOutput.AppendLine("1) foo");
            expectedOutput.AppendLine("2) bang");

            RunCommand("clear");
            expectedOutput.AppendLine("cleared");

            RunCommand("keys");

            VerifyOutput();
        }

        [Test]
        public void KeyExists()
        {

            RunCommand("keyExists foo");
            expectedOutput.AppendLine("false");

            RunCommand("add foo bar");
            expectedOutput.AppendLine("Added");

            RunCommand("keyExists foo");
            expectedOutput.AppendLine("true");

            VerifyOutput();
        }

        [Test]
        public void MemberExists()
        {
            RunCommand("memberExists foo bar");
            expectedOutput.AppendLine("false");

            RunCommand("add foo bar");
            expectedOutput.AppendLine("Added");

            RunCommand("memberExists foo bar");
            expectedOutput.AppendLine("true");

            RunCommand("memberExists foo baz");
            expectedOutput.AppendLine("false");

            VerifyOutput();
        }
        
        [Test]
        public void AllMembers()
        {
            RunCommand("allMembers");

            RunCommand("add foo bar");
            expectedOutput.AppendLine("Added");

            RunCommand("add foo baz");
            expectedOutput.AppendLine("Added");

            RunCommand("allMembers");
            expectedOutput.AppendLine("1) bar");
            expectedOutput.AppendLine("2) baz");

            RunCommand("add bang bar");
            expectedOutput.AppendLine("Added");

            RunCommand("add bang baz");
            expectedOutput.AppendLine("Added");

            RunCommand("allMembers");
            expectedOutput.AppendLine("1) bar");
            expectedOutput.AppendLine("2) baz");
            expectedOutput.AppendLine("3) bar");
            expectedOutput.AppendLine("4) baz");

            VerifyOutput();
        }

        [Test]
        public void Items()
        {
            RunCommand("items");

            RunCommand("add foo bar");
            expectedOutput.AppendLine("Added");

            RunCommand("add foo baz");
            expectedOutput.AppendLine("Added");

            RunCommand("items");
            expectedOutput.AppendLine("1) foo: bar");
            expectedOutput.AppendLine("2) foo: baz");

            RunCommand("add bang bar");
            expectedOutput.AppendLine("Added");

            RunCommand("add bang baz");
            expectedOutput.AppendLine("Added");

            RunCommand("items");
            expectedOutput.AppendLine("1) foo: bar");
            expectedOutput.AppendLine("2) foo: baz");
            expectedOutput.AppendLine("3) bang: bar");
            expectedOutput.AppendLine("4) bang: baz");

            VerifyOutput();
        }

        private void VerifyOutput() =>
            outputProvider.Output
                .Should()
                .BeEquivalentTo(expectedOutput.ToString().Trim());

        private void RunCommand(string command)
        {
            input.Command = command;
            mvd.DoCommand();
        }

    }
}
