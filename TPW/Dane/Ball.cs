using System.ComponentModel;

namespace Dane; 

public class Ball : INotifyPropertyChanged {
    private int _r;

    private double _x,
                    _y,
                    _xsp,
                    _ysp;

    public Ball(double x, double y, int radius, double xSpeed, double ySpeed) {
        X = x;
        Y = y;
        Radius = radius;
        XSpeed = xSpeed;
        YSpeed = ySpeed;
    }


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


    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName) {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}