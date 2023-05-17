using System.ComponentModel;

namespace Dane; 

public abstract class AbstractDaneApi {
    public abstract void MakeMap(int xSize, int ySize);
    public abstract IList<Ball> GetBalls();
    public abstract void AddBall(Ball ball);
    public abstract int GetMapXSize();
    public abstract int GetMapYSize();
    public abstract Map? Map { get; set; }

    public event EventHandler<CollisionEventArgs>? WallCollision;
    public event EventHandler<CollisionEventArgs>? BallCollision;

    public static AbstractDaneApi CreateApi() {
        return new ConcreteDaneApi();
    }

    private sealed class ConcreteDaneApi : AbstractDaneApi {
        private Map? _map;

        public override Map? Map {
            get => _map;
            set {
                _map = value;
                if (_map == null) return;
                _map.WallCollision += WallCollision;
                _map.BallCollision += BallCollision;
            }
        }

        public override void MakeMap(int xSize, int ySize) {
            Map = new Map(xSize, ySize);
        }

        public override IList<Ball> GetBalls() {
            return Map?.Balls ?? new List<Ball>();
        }

        public override void AddBall(Ball ball) {
            Map?.AddBall(ball);
        }

        public override int GetMapXSize() {
            return Map?.XSize ?? 0;
        }

        public override int GetMapYSize() {
            return Map?.YSize ?? 0;
        }
    }
}