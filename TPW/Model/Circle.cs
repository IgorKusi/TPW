using System.ComponentModel;
using Dane;
using Logika;

namespace Model {
    public class Circle : INotifyPropertyChanged {
        public static Circle GetCircle(Map forMap, int radius) {
            var b = BallManager.GenerateBall(forMap);
            return new Circle(b, radius);
        }

        private Circle(Ball ball, int radius) {
            Ball = ball;
            Radius = radius;

            ball.PropertyChanged += RelayBallUpdate;
        }

        public Ball Ball { get; }
        public int Radius { get; }

        public double X {
            get => Ball.X;
            set => Ball.X = value;
        }
        public double Y {
            get => Ball.Y;
            set => Ball.Y = value;
        }



        private void RelayBallUpdate(object? source, PropertyChangedEventArgs args) {
            this.OnPropertyChanged(args);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args) {
            PropertyChanged?.Invoke(this, args);
        }
    }
}