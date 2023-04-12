using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dane;
using Logika;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Testy {
    [TestClass]
    public class ModelTests {
        [TestMethod]
        public void CircleTest()
        {
            int callCount = 0;
            
            Map map = new Map(100, 100);
            Circle circle = Circle.GetCircle(map, 5);
            Circle circle1 = Circle.GetCircle(map, 5);

            Assert.AreEqual(5, circle.Radius);

            circle.PropertyChanged += (sender, args) => { callCount++; };
            circle.Ball.PropertyChanged += (sender, args) => { callCount++; };
            circle1.PropertyChanged += (sender, args) => { callCount++; };
            circle1.Ball.PropertyChanged += (sender, args) => { callCount++; };

            foreach (var ball in map.Balls)
            {
                BallManager.UpdateBallPos(ball);
            }

            Assert.AreEqual(4, callCount);
        }



        [TestMethod]
        public void ModelTest()
        {
            var callCount = 0;

            Model.Model model = new(5, 100, 100);

            foreach ( var circle in model.Circles ) {
                circle.PropertyChanged += (sender, args) => { ++callCount; };
            }
            model.Start();

            Thread.Sleep(2000);


            model.Stop();
            var count1 = callCount;
            Thread.Sleep(1000);
            Assert.AreEqual(count1, callCount);


            Assert.AreEqual(5, model.Map.Balls.Count);
            Assert.AreEqual(5, model.Circles.Count);
            Assert.AreEqual(100, model.Map.XSize);
            Assert.AreEqual(100, model.Map.YSize);

            Assert.IsTrue(callCount > 0);
        }

    }
}
