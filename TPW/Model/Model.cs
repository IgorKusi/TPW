using System.Collections.ObjectModel;
using Dane;
using Logika;

namespace Model {
    public class Model {
        public Model(int numBalls, int mapX, int mapY) {
            BallRadius = 15;
            Circles = new ObservableCollection<Circle>();
            Map = new Map(mapX, mapY);

            for ( var i = 0; i < numBalls; i++ ) {
                Circles.Add(Circle.GetCircle(Map, BallRadius));
            }
        }

        private readonly ManualResetEvent _mre = new(false);
        public int BallRadius { get; }

        private bool _enabled;
        public bool Enabled {
            get => _enabled;
            set {
                _enabled = value;
                if ( _enabled ) _mre.Set();
                else _mre.Reset();
            }
        }

        public ObservableCollection<Circle> Circles { get; }

        public Map Map { get; }
        private List<Thread> _threads = new();

        public void Start() {
            Enabled = true;

            for ( var i = 0; i < Circles.Count; i++ ) {
                var circle = Circles[ i ];
                Thread t = new(() => {
                    while ( true ) {
                        try {
                            _mre.WaitOne();
                            BallManager.UpdateBallPos(circle.Ball);

                            Thread.Sleep(5);
                        } catch ( ThreadInterruptedException e ) {
                            return;
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
            Enabled = false;
            _threads.Clear();
        }

    }
}
