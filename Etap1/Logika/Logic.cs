namespace Logika {
    public class Logic {

        public static Dane.Map CreateMap(int xsize, int ysize) => new(xsize, ysize);
        public static void SpawnBall(Dane.Map targetMap, int x, int y) {
            targetMap.AddBall(BallGenerator.Instance.GetBall(x, y));
        }
    }

}