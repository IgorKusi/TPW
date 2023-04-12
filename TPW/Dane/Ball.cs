using System;
using System.ComponentModel;
using System.Numerics;

namespace Dane {
    public class Ball : INotifyPropertyChanged {
        private int _x;
        private int _y;

        public Ball(int x, int y, int xSpeed, int ySpeed) {
            X = x;
            Y = y;
            XSpeed = xSpeed;
            YSpeed = ySpeed;
        }


        public int X {
            get => _x;
            set {
                _x = value;
                OnPropertyChanged("x");
            }
        }

        public int Y {
            get => _y;
            set {
                _y = value;
                OnPropertyChanged("y");
            }
        }

        public int XSpeed { get; set; }
        public int YSpeed { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName) {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}