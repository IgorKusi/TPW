using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;

namespace Logika {
    public static class BallManager {
        public static Ball GenerateBall(Dane.Map forMap)
        {
            Ball ret = new(
                ThreadSafeRandom.Next(forMap.XSize - 1) + 1,
                ThreadSafeRandom.Next(forMap.YSize - 1) + 1,
                ThreadSafeRandom.Next(7) - 3,
                ThreadSafeRandom.Next(7) - 3
            );
            forMap.AddBall(ret);
            return ret;
        }

        public static void UpdateBallPos(Dane.Ball ball) {
            ball.X += ball.XSpeed;
            ball.Y += ball.YSpeed;
            ball.OnPropertyChanged("pos");
        }

        
    }
}
