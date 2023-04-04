namespace Dane
{
    public class Ball
    {
        public int X { get; }
        public int Y { get; }
        public void ChangePosition(int newX, int newY)
        {
            X = newX;
            Y = newY;
            BallChangedEvent.Raise(newX, newY);
        }
        public event BallChangedEvent;
        }
    }