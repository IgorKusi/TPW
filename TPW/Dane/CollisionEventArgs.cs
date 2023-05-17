namespace Dane;


public class CollisionEventArgs : EventArgs {
    public CollisionEventArgs(Ball ball1, Ball? ball2, Map map) {
        Ball1 = ball1;
        Ball2 = ball2;
        Map = map;
    }

    public Ball Ball1 { get; }
    public Ball? Ball2 { get; }
    public Map Map { get; }
}
