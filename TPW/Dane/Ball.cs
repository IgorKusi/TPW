using System.ComponentModel;

namespace Dane; 

public class Ball : INotifyPropertyChanged {
    private int _id,
                    _r;

    private double _x,
                    _y,
                    _xsp,
                    _ysp;

    public Ball(int id, double x, double y, int radius, double xSpeed, double ySpeed) {
        _id = id;
        X = x;
        Y = y;
        Radius = radius;
        XSpeed = xSpeed;
        YSpeed = ySpeed;
    }

    
    private readonly int _mass = new Random().Next(1, 10);
    public int Mass => _mass;

    public int Id => _id;

    public double X {
        get => _x;
        set {
            _x = value;
            OnPropertyChanged("x");
        }
    }

    public double Y {
        get => _y;
        set {
            _y = value;
            OnPropertyChanged("y");
        }
    }

    public int Radius {
        get => _r;
        set {
            _r = value;
            OnPropertyChanged("radius");
        }
    }

    public double XSpeed {
        get => _xsp;
        set {
            _xsp = value;
            OnPropertyChanged("xspeed");
        }
    }

    public double YSpeed {
        get => _ysp;
        set {
            _ysp = value;
            OnPropertyChanged("yspeed");
        }
    }

    public void UpdatePos() {
        X += XSpeed;
        Y += YSpeed;
        OnPropertyChanged("pos");
    }

    public bool IsColliding(Ball withOther) {
        double dist = Math.Sqrt(Math.Pow(withOther.X - X, 2) +
                               Math.Pow(withOther.Y - Y, 2));
        if (
            dist <= Radius
        ) return true;
        return false;
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName) {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}