using Dane;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testy;

[TestClass]
public class DaneTests {
    [TestMethod]
    public void BallTest() {
        Ball b = new(5, 5, 5, 4, -3);
        int cnt = 0;
        b.PropertyChanged += (_, _) => cnt++;
        b.UpdatePos();
        b.UpdatePos();
        Assert.AreEqual(6, cnt);
        Assert.AreEqual(5 + 4 + 4, b.X);
        Assert.AreEqual(5 - 3 - 3, b.Y);
        Assert.AreEqual(5, b.Radius);
    }

    [TestMethod]
    public void MapTest() {
        Map map = new(100, 100);
        map.AddBall(new Ball(5, 5, 5, 5, 5));
        Assert.AreEqual(100, map.XSize);
        Assert.AreEqual(100, map.YSize);
        Assert.AreEqual(1, map.Balls.Count);
    }

    [TestMethod]
    public void DaneApiTest() {
        var dApi = AbstractDaneApi.CreateApi();
        dApi.MakeMap(100, 100);
        dApi.AddBall(new Ball(5, 5, 5, 5, 5));
        Assert.AreEqual(100, dApi.GetMapXSize());
        Assert.AreEqual(100, dApi.GetMapYSize());
        Assert.AreEqual(1, dApi.GetBalls().Count);
        Assert.IsNotNull(dApi.Map);
        Assert.AreEqual(100, dApi.Map.XSize);
        Assert.AreEqual(100, dApi.Map.YSize);
        Assert.AreEqual(1, dApi.Map.Balls.Count);
    }
}