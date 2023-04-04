using Dane;
using System.Xml.Linq;

namespace Logika {
    public class Map {

        public int Xsize { get; set; }
        public int Ysize { get; set; }
        public IList<Ball> Balls;

        public Map(int xsize, int ysize) {
            Xsize = xsize; 
            Ysize = ysize;
            Balls = new List<Ball>();
            
        }
    }
}