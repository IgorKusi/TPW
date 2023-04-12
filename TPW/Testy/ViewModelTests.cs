using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace Testy {
    [TestClass]
    public class ViewModelTests {
        [TestMethod]
        public void ButtonActionTest() {
            var cnt = 0;
            ICommand OnFire = new ButtonAction(() => ++cnt);
            Assert.IsTrue(OnFire.CanExecute(null));
            OnFire.Execute(null);
            Assert.AreEqual(1, cnt);
        }

        [TestMethod]
        public void ControllerTest()
        {
            var cnt = 0;
            Controller ctx = new();
            Assert.IsNull(ctx.Circles);
            Assert.IsTrue(ctx.OnButtonStart.CanExecute(null));
            Assert.IsTrue(ctx.OnButtonStop.CanExecute(null));
            Assert.AreEqual(1, ctx.BallNum);

            ctx.OnButtonStart.Execute(null);
            Assert.IsNotNull(ctx.Circles);
            Assert.AreEqual(1, ctx.Circles.Count);
            foreach (var circle in ctx.Circles)
            {
                circle.PropertyChanged += (sender, args) => { Console.WriteLine(++cnt); };
                circle.Ball.PropertyChanged += (sender, args) => { Console.WriteLine(++cnt); };
            }
            Assert.AreEqual(1, ctx.BallNum);

            Thread.Sleep(2000);
            Assert.AreNotEqual(0, cnt);

            ctx.OnButtonStop.Execute(null);
            var cnt1 = cnt;
            Thread.Sleep(2000);
            Assert.AreEqual(cnt1, cnt);
        }


    }
}
