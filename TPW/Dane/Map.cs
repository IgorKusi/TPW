namespace Dane;

public class Map {
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
    }
}