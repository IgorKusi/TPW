using System.ComponentModel;

namespace Dane;

public partial class Map {
    public Map(int xSize, int ySize) {
        XSize = xSize;
        YSize = ySize;
        _balls = new List<Ball>();
    }

    public int XSize { get; }
    public int YSize { get; }

    private readonly List<Ball> _balls;
    public IList<Ball> Balls => _balls.AsReadOnly();

    public void AddBall(Ball ball) {
        _balls.Add(ball);
        ball.PropertyChanged += CheckCollision;
    }

    private void CheckCollision(object? source, PropertyChangedEventArgs args) {
        if ( args.PropertyName != "pos" ) return;
        if ( source == null ) return;

        Ball src = (Ball) source;
        if ( src.X - src.Radius <= 0 || src.X + src.Radius >= this.XSize || src.Y - src.Radius <= 0 ||
             src.Y + src.Radius >= this.YSize )
            InvokeWallCollision(src);
        else {
            foreach (Ball otherBall in _balls) {
                if ( otherBall.Id == src.Id ) continue;
                if ( src.IsColliding(otherBall) ) InvokeBallCollision(src, otherBall);
            }
        }
    }

    public event EventHandler<CollisionEventArgs>? WallCollision;

    private void InvokeWallCollision(Ball ball) {
        WallCollision?.Invoke(this, new CollisionEventArgs(ball, null, this));
    }

    public event EventHandler<CollisionEventArgs>? BallCollision;

    private void InvokeBallCollision(Ball ball1, Ball ball2) {
        BallCollision?.Invoke(this, new CollisionEventArgs(ball1, ball2, this));
    }
}