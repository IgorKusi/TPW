using Dane;

namespace Logika;

public static class BallManager {
    private static int _ballId;
    private static object lck = new object();

    public static Ball GenerateBall(Map forMap, int ballRadius) {
        Ball ret = new(
            _ballId,
            ThreadSafeRandom.Next(forMap.XSize - 10 * ballRadius) + 5 * ballRadius,
            ThreadSafeRandom.Next(forMap.YSize - 10 * ballRadius) + 5 * ballRadius,
            ballRadius,
            ThreadSafeRandom.Next(7) - 3,
            ThreadSafeRandom.Next(7) - 3
        );
        forMap.AddBall(ret);
        ++_ballId;
        return ret;
    }

    //Handle Physics
    public static void HandleWallCollision(object? sender, CollisionEventArgs args) {
        Ball ball = args.Ball1;
        Map map = args.Map;

            
        lock (lck) {
            ball.X -= ball.XSpeed;
            ball.Y -= ball.YSpeed;

            while ( ball.X - ball.Radius > 0 && ball.X + ball.Radius < map.XSize && ball.Y - ball.Radius > 0 &&
                    ball.Y + ball.Radius < map.YSize ) {
                ball.X += 1 * Math.Sign(ball.XSpeed);
                ball.Y += 1 * Math.Sign(ball.YSpeed);
            }

            ball.X -= 1 * Math.Sign(ball.XSpeed);
            ball.Y -= 1 * Math.Sign(ball.YSpeed);

            if ( ball.X + ball.XSpeed - ball.Radius <= 0 || ball.X + ball.XSpeed + ball.Radius >= map.XSize )
                ball.XSpeed *= -1;
            else if ( ball.Y + ball.YSpeed - ball.Radius <= 0 || ball.Y + ball.YSpeed + ball.Radius >= map.YSize )
                ball.YSpeed *= -1;
        }
    }

    public static void HandleBallCollision(object? sender, CollisionEventArgs args) {
        if ( args.Ball2 == null ) return;

        Ball ball1 = args.Ball1;
        Ball ball2 = args.Ball2;

            
        lock (lck) {
            ball1.X -= ball1.XSpeed;
            ball1.Y -= ball1.YSpeed;
            ball2.X -= ball2.XSpeed;
            ball2.Y -= ball2.YSpeed;

            while ( !ball1.IsColliding(ball2) ) {
                ball1.X += 1 * Math.Sign(ball1.XSpeed);
                ball1.Y += 1 * Math.Sign(ball1.YSpeed);
                ball2.X += 1 * Math.Sign(ball2.XSpeed);
                ball2.Y += 1 * Math.Sign(ball2.YSpeed);
            }

            ball1.X -= 2 * Math.Sign(ball1.XSpeed);
            ball1.Y -= 2 * Math.Sign(ball1.YSpeed);
            ball2.X -= 2 * Math.Sign(ball2.XSpeed);
            ball2.Y -= 2 * Math.Sign(ball2.YSpeed);

            ball1.XSpeed =
                (ball1.Mass * ball1.XSpeed + ball2.Mass * ball2.XSpeed +
                 ball2.Mass * 1 * (ball2.XSpeed - ball1.XSpeed)) /
                (ball1.Mass + ball2.Mass);
            ball2.XSpeed =
                (ball1.Mass * ball1.XSpeed + ball2.Mass * ball2.XSpeed +
                 ball2.Mass * 1 * (ball1.XSpeed - ball2.XSpeed)) /
                (ball1.Mass + ball2.Mass);
            ball1.YSpeed =
                (ball1.Mass * ball1.YSpeed + ball2.Mass * ball2.YSpeed +
                 ball2.Mass * 1 * (ball2.YSpeed - ball1.YSpeed)) /
                (ball1.Mass + ball2.Mass);
            ball2.YSpeed =
                (ball1.Mass * ball1.YSpeed + ball2.Mass * ball2.YSpeed +
                 ball2.Mass * 1 * (ball1.YSpeed - ball2.YSpeed)) /
                (ball1.Mass + ball2.Mass);
        }
    }
}