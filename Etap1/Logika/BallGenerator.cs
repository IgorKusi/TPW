namespace Logika {
    public class BallGenerator {
        private BallGenerator() { }
        private static BallGenerator? _instance;
        private static readonly object _lock = new();


        public static BallGenerator Instance {
            get {
                if ( _instance == null ) {
                    lock ( _lock ) {
                        if ( _instance == null ) {
                            _instance = new BallGenerator();
                        }
                    }
                }

                return _instance;
            }
        }

        private int _ballId = 0;

        public Dane.Ball GetBall(int x, int y) {
            Dane.Ball b = new Dane.Ball(_ballId);
            b.ChangePosition(x, y);
            _ballId++;
            return b;
        }

        public static Tuple<int, int> GeneratePosition(int x_limit, int y_limit) 
            => new(ThreadSafeRandom.Next(x_limit), ThreadSafeRandom.Next(y_limit));

    }
}
