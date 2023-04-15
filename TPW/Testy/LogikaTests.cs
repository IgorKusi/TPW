using System.Linq;
using System.Threading;
using Dane;
using Logika;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy; 

[TestClass]
public class LogikaTests {
    [TestMethod]
    public void BallManagerTests() {
        Map map = new(100, 100);
        BallManager.GenerateBall(map, 15);
        BallManager.GenerateBall(map, 3);

        Assert.AreEqual(2, map.Balls.Count);
        Assert.AreEqual(15, map.Balls[ 0 ].Radius);
        Assert.AreEqual(3, map.Balls[ 1 ].Radius);
    }

    [TestMethod]
    public void LogikaApiTests() {
        var lApi = AbstractLogikaApi.CreateApi(100, 100, 5, 13);
        Assert.AreEqual(5, lApi.GetBalls().Count());
        int cnt = 0;
        foreach (var ball in lApi.GetBalls()) {
            Assert.AreEqual(13, ball.Radius);
            ball.PropertyChanged += (_, _) => cnt++;
        }

        lApi.Stop();
        Assert.AreEqual(0, cnt);

        lApi.Start();
        Thread.Sleep(100);
        lApi.Stop();
        Assert.IsTrue(cnt > 0);
    }
}