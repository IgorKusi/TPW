using System.Diagnostics;
using Dane;

namespace Logika;

public abstract class AbstractLogikaApi {
    public static AbstractLogikaApi CreateApi(int xSize, int ySize, int numBalls, int ballRadius,
        AbstractDaneApi? dApi = null) {
        return new ConcreteLogikaApi(xSize, ySize, numBalls, ballRadius, dApi);
    }

    public virtual bool Enabled { get; set; }
    public abstract IEnumerable<Ball> GetBalls();
    public abstract void Start();
    public abstract void Stop();


    private sealed class ConcreteLogikaApi : AbstractLogikaApi {
        private readonly object _lock = new();
        private readonly List<Thread> _threads = new();
        private readonly ManualResetEvent _mre = new(false);
        private readonly AbstractDaneApi _dApi;


        private bool _enabled;

        public override bool Enabled {
            get => _enabled;
            set {
                _enabled = value;
                if ( _enabled ) _mre.Set();
                else _mre.Reset();
            }
        }

        public override IEnumerable<Ball> GetBalls() {
            return _dApi.GetBalls();
        }

        public ConcreteLogikaApi(int xSize, int ySize, int numBalls, int ballRadius, AbstractDaneApi? dApi = null) {
            _dApi = dApi ?? AbstractDaneApi.CreateApi();
            
            _dApi.BallCollision += BallManager.HandleBallCollision;
            _dApi.WallCollision += BallManager.HandleWallCollision;
            
            _dApi.MakeMap(xSize, ySize);
            Debug.Assert(_dApi.Map != null);

            for (int i = 0; i < numBalls; i++) {
                BallManager.GenerateBall(_dApi.Map, ballRadius);
            }
        }


        public override void Start() {
            Enabled = true;

            for (var i = 0; i < _dApi.GetBalls().Count; i++) {
                var ball = _dApi.GetBalls()[ i ];
                Thread t = new(() => {
                    while ( true ) {
                        try {
                            _mre.WaitOne();
                            lock (_lock) {
                                ball.UpdatePos();
                            }

                            Thread.Sleep(5);
                        }
                        catch (ThreadInterruptedException e) {
                            return;
                        }
                    }
                }) {
                    Name = "Update thread for circle " + i
                };

                _threads.Add(t);
                t.Start();
            }
        }

        public override void Stop() {
            foreach (var thread in _threads) {
                thread.Interrupt();
            }

            Enabled = false;
            _threads.Clear();
        }
    }
}