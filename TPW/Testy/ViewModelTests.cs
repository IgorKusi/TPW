using System.Threading;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViewModel;

namespace Testy;

[TestClass]
public class ViewModelTests {
    [TestMethod]
    public void ButtonActionTest() {
        var cnt = 0;
        ICommand onFire = new ButtonAction(() => ++cnt);
        Assert.IsTrue(onFire.CanExecute(null));
        onFire.Execute(null);
        Assert.AreEqual(1, cnt);
    }

    [TestMethod]
    public void ControllerTest() {
        var cnt = 0;
        Controller ctx = new();
        Assert.AreEqual(0, ctx.Circles.Count);
        Assert.IsTrue(ctx.OnButtonStart.CanExecute(null));
        Assert.IsTrue(ctx.OnButtonStop.CanExecute(null));
        Assert.AreEqual(1, ctx.BallNum);

        ctx.OnButtonStart.Execute(null);
        Assert.IsNotNull(ctx.Circles);
        Assert.AreEqual(1, ctx.Circles.Count);
        foreach (var circle in ctx.Circles) {
            circle.PropertyChanged += (_, _) => cnt++;
            circle.Ball.PropertyChanged += (_, _) => cnt++;
        }

        Assert.AreEqual(1, ctx.BallNum);

        Thread.Sleep(200);
        Assert.AreNotEqual(0, cnt);

        ctx.OnButtonStop.Execute(200);
        var cnt1 = cnt;
        Thread.Sleep(200);
        Assert.AreEqual(cnt1, cnt);
    }
}