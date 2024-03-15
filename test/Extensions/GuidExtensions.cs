using NUnit.Framework;
using PolyhydraGames.Core.Maui.Extensions;

namespace PolyhydraGames.Core.Maui.Test.Extensions;

[TestFixture]
public   class ColorExtensionTests
{
    [TestCase("#00000000")]
    public   void BlackColorTest( string value)
    {
        var color = value.ToColor();
        Assert.That(color == ColorDefs.Black);
    }

    [TestCase("#FFFFFFFF")]
    public void WhiteColorTest(string value)
    {
        var color = value.ToColor();
        Assert.That(color == ColorDefs.White);
    }


}