using System.ComponentModel;
using Dane;
using Logika;

namespace Model; 

public sealed class Circle : INotifyPropertyChanged {
    public static Circle GetCircle(Map forMap, int radius) {
        var b = BallManager.GenerateBall(forMap, radius);
        return new Circle(b);
    }

    public Circle(Ball ball) {
        Ball = ball;
        Radius = ball.Radius;

        ball.PropertyChanged += RelayBallUpdate;
    }

    public Ball Ball { get; }
    public int Radius { get; }

    public double X {
        get => Ball.X - Ball.Radius;
        set => Ball.X = value;
    }

    public double Y {
        get => Ball.Y - Ball.Radius;
        set => Ball.Y = value;
    }


    private void RelayBallUpdate(object? source, PropertyChangedEventArgs args) {
        this.OnPropertyChanged(args);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(PropertyChangedEventArgs args) {
        PropertyChanged?.Invoke(this, args);
    }
}