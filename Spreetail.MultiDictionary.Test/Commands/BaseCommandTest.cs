using NUnit.Framework;

namespace Spreetail.MultiDictionary.Test.Commands;

internal class BaseCommandTest
{
    private protected OutputProvider outputProvider = null!;

    [SetUp]
    public void SetUp()
    {
        outputProvider = new OutputProvider();
    }
}