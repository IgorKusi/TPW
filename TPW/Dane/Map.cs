using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Dane {
    public class Map {
        public Map(int xSize, int ySize) {
            XSize = xSize;
            YSize = ySize;
            _balls = new List<Ball>();

        }

        public int XSize { get; set; }
        public int YSize { get; set; }

        private List<Ball> _balls;
        public IList<Ball> Balls => _balls.AsReadOnly();

        public void AddBall(Ball ball) {
            _balls.Add(ball);
        }
        
    }
}