using System.ComponentModel;

namespace Dane {
    public class Ball : INotifyPropertyChanged {
        private double _x;
        private double _y;

        public Ball(double x, double y, double xSpeed, double ySpeed) {
            X = x;
            Y = y;
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

        public double XSpeed { get; set; }
        public double YSpeed { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName) {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}