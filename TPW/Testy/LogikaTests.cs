using System;
using System.ComponentModel;
using System.Data;
using Dane;
using Logika;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy {
    [TestClass]
    public class LogikaTests {

        [TestMethod]
        public void LogikaTest() {
            Ball b = new(1, 2, 3, 4);
            BallManager.UpdateBallPos(b);
            Assert.AreEqual(4, b.X);
            Assert.AreEqual(6, b.Y);

            var cnt = 0;
            Map map = new(100, 100);
            BallManager.GenerateBall(map).PropertyChanged += (object? sender, PropertyChangedEventArgs args) => { cnt++; };
            BallManager.GenerateBall(map).PropertyChanged += (object? sender, PropertyChangedEventArgs args) => { cnt++; };
            foreach ( var ball in map.Balls ) {
                BallManager.UpdateBallPos(ball);
            }
            Assert.AreEqual(2, cnt);

        }
    }
}