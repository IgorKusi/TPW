using Dane;

namespace Logika; 

public static class BallManager {
    public static Ball GenerateBall(Map forMap, int ballRadius) {
        Ball ret = new(
            ThreadSafeRandom.Next(forMap.XSize - 1) + 1,
            ThreadSafeRandom.Next(forMap.YSize - 1) + 1,
            ballRadius,
            ThreadSafeRandom.Next(7) - 3,
            ThreadSafeRandom.Next(7) - 3
        );
        forMap.AddBall(ret);
        return ret;
    }

    //Handle Physics
}