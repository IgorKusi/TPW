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
                ball1.X += ball1.XSpeed / 10;
                ball1.Y += ball1.YSpeed / 10;
                ball2.X += ball2.XSpeed / 10;
                ball2.Y += ball2.YSpeed / 10;
            }
            
            ball1.X -= 2 * Math.Sign(ball1.XSpeed);
            ball1.Y -= 2 * Math.Sign(ball1.YSpeed);
            ball2.X -= 2 * Math.Sign(ball2.XSpeed);
            ball2.Y -= 2 * Math.Sign(ball2.YSpeed);


            if ( ball1.XSpeed == 0 ) ball1.XSpeed += 0.0001;
            if ( ball2.XSpeed == 0 ) ball2.XSpeed += 0.0001;
            
            double theta1 = Math.Atan(ball1.YSpeed / ball1.XSpeed);
            double theta2 = Math.Atan(ball2.YSpeed / ball2.XSpeed);

            if ( theta1 == 0 ) theta1 += 0.0001;
            if ( theta2 == 0 ) theta2 += 0.0001;

            double v1 = ball1.YSpeed / Math.Sin(theta1);//Math.Sqrt(ball1.YSpeed * ball1.YSpeed + ball1.XSpeed * ball1.XSpeed);
            double v2 = ball2.YSpeed / Math.Sin(theta2);//Math.Sqrt(ball2.YSpeed * ball2.YSpeed + ball2.XSpeed * ball2.XSpeed);
            
            

            double dOx = ball2.X - ball1.X;
            double dOy = ball2.Y - ball1.Y;
            double phi = Math.Atan(dOy / dOx);


            float dM = ball2.Mass - ball1.Mass;

            double v1fx = ( (v1 * Math.Cos(theta1 - phi) * (-dM) + 2 * ball2.Mass * v2 * Math.Cos(theta2 - phi)) /
                            (ball1.Mass + ball2.Mass) ) * Math.Cos(phi) +
                          v1 * Math.Sin(theta1 - phi) * Math.Cos(phi + Math.PI / 2);
            double v1fy = ( (v1 * Math.Cos(theta1 - phi) * (-dM) + 2 * ball2.Mass * v2 * Math.Cos(theta2 - phi)) /
                            (ball1.Mass + ball2.Mass) ) * Math.Sin(phi) +
                          v1 * Math.Sin(theta1 - phi) * Math.Sin(phi + Math.PI / 2);
            double v2fx = ( (v2 * Math.Cos(theta2 - phi) * dM + 2 * ball1.Mass * v1 * Math.Cos(theta1 - phi)) /
                            (ball1.Mass + ball2.Mass) ) * Math.Cos(phi) +
                          v2 * Math.Sin(theta2 - phi) * Math.Cos(phi + Math.PI / 2);
            double v2fy = ( (v2 * Math.Cos(theta2 - phi) * dM + 2 * ball1.Mass * v1 * Math.Cos(theta1 - phi)) /
                            (ball1.Mass + ball2.Mass) ) * Math.Sin(phi) +
                          v2 * Math.Sin(theta2 - phi) * Math.Sin(phi + Math.PI / 2);

            ball1.XSpeed = v1fx;
            ball1.YSpeed = v1fy;
            ball2.XSpeed = v2fx;
            ball2.YSpeed = v2fy;

            if ( double.IsNaN(ball1.XSpeed) || double.IsNaN(ball1.YSpeed) || double.IsNaN(ball2.XSpeed) ||
                 double.IsNaN(ball2.YSpeed) ) {
                var a = 3;
            }
        }


    }
}