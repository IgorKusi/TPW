using Calc;
using System;
using NUnit.Framework;

namespace TestEtap
{
    
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Kalkulator kalkulator = new Kalkulator();
            Assert.True(kalkulator.Dodawanie(1, 2, 3, 4) == 10); ;
            Assert.True(kalkulator.Dodawanie(5,5) == 10);
            Assert.True(kalkulator.Potegowanie(2, 10) == 1024);
            Assert.True(kalkulator.Dzielene(10,5) == 2);
            Assert.True(kalkulator.Mnozenie(5,10) == 50);
            Assert.True(kalkulator.Odejmowanie(3,2) == 1);
        }
    }
}