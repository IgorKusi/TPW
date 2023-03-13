using System;
using System.Runtime.ConstrainedExecution;

namespace XD
{
    public class Kalkulatorek
    {
        public static int Dodawanko(int x, int y) => x + y;

        public static int Odejmowanko(int x, int y) => x - y;
    }

}

namespace Etap0
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine(XD.Kalkulatorek.Dodawanko(1,2));
            Console.WriteLine(XD.Kalkulatorek.Odejmowanko(10,5));
        }
    }
}