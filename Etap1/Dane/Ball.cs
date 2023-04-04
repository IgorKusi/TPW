namespace Dane {
    public class Ball {
        public Ball(int id)
        {
            Id = id;
        }

        public int Id { get; }


        public int X { get; private set; }
        public int Y { get; private set; }
        public void ChangePosition(int newX, int newY)
        {
            X = newX;
            Y = newY;
            BallChangedEvent?.Invoke(this, new BallEventArgs(Id, newX, newY));
        }

        public event EventHandler? BallChangedEvent;
    }

    public class BallEventArgs : EventArgs
    {
        private readonly int ballId;
        private readonly int newX;
        private readonly int newY;

        public BallEventArgs(int ballId, int newX, int newY)
        {
            this.ballId = ballId;
            this.newX = newX;
            this.newY = newY;
        }
    }
}