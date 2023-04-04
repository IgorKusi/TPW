namespace Logika {
    public class ThreadSafeRandom {
        private static readonly Random _global = new();
        [ThreadStatic] private static Random? _local;

        public static int Next(int? maxVal = null) {
            if ( _local == null ) {
                int seed;
                lock ( _global ) {
                    seed = _global.Next();
                }
                _local = new Random(seed);
            }

            if ( maxVal == null ) 
                return _local.Next();
            else return _local.Next((int) maxVal);
        }
    }
}