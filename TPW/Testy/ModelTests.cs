using System.Threading;
using Dane;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Testy;

[TestClass]
public class ModelTests {
    [TestMethod]
    public void CircleTest() {
        int cnt = 0;

        Map map = new(100, 100);
        var circle = Circle.GetCircle(map, 5);
        var circle1 = Circle.GetCircle(map, 5);

        Assert.AreEqual(5, circle.Radius);

        circle.PropertyChanged += (_, _) => cnt++;
        circle.Ball.PropertyChanged += (_, _) => cnt++;
        circle1.PropertyChanged += (_, _) => cnt++;
        circle1.Ball.PropertyChanged += (_, _) => cnt++;

        foreach (var ball in map.Balls) {
            ball.UpdatePos();
        }

        Assert.AreEqual(12, cnt);
    }


    [TestMethod]
    public void ModelApiTest() {
        var callCount = 0;

        var mApi = AbstractModelApi.CreateApi(100, 100, 5, 15);

        foreach (var circle in mApi.Circles) {
            circle.PropertyChanged += (_, _) => { ++callCount; };
        }

        mApi.Start();

        Thread.Sleep(200);


        mApi.Stop();
        var count1 = callCount;
        Thread.Sleep(100);
        Assert.AreEqual(count1, callCount);

        Assert.IsTrue(callCount > 0);
    }
}