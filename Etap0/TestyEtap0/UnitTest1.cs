using Assert = NUnit.Framework.Assert;
using NUnit;

namespace TestyEtap0;

public class Tests
{
    [NUnit.Framework.SetUp]
    public void Setup()
    {
        
    }

    [NUnit.Framework.Test]
    public void Test1()
    {
        Assert.Equals(XD.Kalkulatorek.Dodawanko(2, 3), 5);
    }
}