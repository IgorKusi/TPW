namespace Dane {
    public class Map {

        public int Xsize { get; set; }
        public int Ysize { get; set; }
        private List<Ball> _balls;
        public IList<Ball> Balls {
            get => _balls.AsReadOnly();
            private set { _balls = (List<Ball>) value; }
        }

        public void AddBall(Ball ball) {
            _balls.Add(ball);
            ball.BallChangedEvent += HandleBallChanged;
            BallInMapChangedEvent?.Invoke(this, new BallEventArgs(ball.Id, ball.X, ball.Y));
        }

        public Map(int xsize, int ysize) {
            Xsize = xsize; 
            Ysize = ysize;
            _balls = new List<Ball>();
            
        }

        public event EventHandler? BallInMapChangedEvent;

        void HandleBallChanged(object? sender, EventArgs e) { 
            BallInMapChangedEvent?.Invoke(sender, e);
        }

    }
}