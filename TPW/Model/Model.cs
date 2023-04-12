using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dane;
using Logika;

namespace Model {
    public class Model {
        public Model(int numBalls, int mapX, int mapY) {
            BallRadius = 50;
            _circles = new ObservableCollection<Circle>();
            Map = new Map(mapX, mapY);

            for ( var i = 0; i < numBalls; i++ ) {
                _circles.Add(Circle.GetCircle(Map, BallRadius));
            }
        }

        public int BallRadius { get; }

        private ObservableCollection<Circle> _circles;
        public ObservableCollection<Circle> Circles => _circles;
        public Map Map { get; }
        private List<Thread> _threads = new();

        public void Start() {
            for ( var i = 0; i < Circles.Count; i++ ) {
                var circle = Circles[ i ];
                Thread t = new(() => {
                    while ( true ) {
                        BallManager.UpdateBallPos(circle.Ball);

                        try {
                            Thread.Sleep(500);
                        } catch ( ThreadInterruptedException e ) {
                            break;
                        }
                    }
                });
                t.Name = "Update thread for circle " + i;

                _threads.Add(t);
                t.Start();
            }
        }

        public void Stop() {
            foreach ( var thread in _threads ) {
                thread.Interrupt();
            }
        }

    }
}
