using XD;
using System;
using NUnit.Framework;

namespace TestEtap
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Assert.True(Kalkulatorek.Dodawanko(1,2) == 3);
            Assert.False(Kalkulatorek.Odejmowanko(2,3) == -10);
        }
    }
}