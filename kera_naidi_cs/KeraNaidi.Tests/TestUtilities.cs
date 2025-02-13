using KeraNaidi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KeraNaidi.Tests;

[TestClass]
public class TestUtilities
{
    [TestMethod]
    public void GenerateRandomCodes()
    {
        var _utilities = new Utilities();
        var result = _utilities.GenerateRandomCodes(20);
        Assert.IsNotEmpty(result);
    }
}
