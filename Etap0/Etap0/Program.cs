using System;
using System.ComponentModel.Design;
using System.Runtime.ConstrainedExecution;
using Calc;

namespace Calc
{
    public class Kalkulator 
    {
        public double Dodawanie(params int[] tab)
        {
            int suma = 0;
            foreach (var n1 in tab)
            {
                suma += n1;
            }

            return suma;
        }

        public double Odejmowanie(double n1, double n2)
        {
            return n1 - n2;
        }

        public double Mnozenie(double n1, double n2)
        {
            return n1 * n2;
        }

        public double Dzielene(double n1, double n2)
        {
            return n1 / n2;
        }

        public double Potegowanie(double podstawa, int wykladnik)
        {
            if (wykladnik < 0) return 0;
            if (podstawa == 0) return 0;
            if (wykladnik == 0) return 1;
            double wynik = podstawa;
            for (int i = 1; i < wykladnik; i++)
            {
                wynik = wynik * podstawa;
            }

            return wynik;
        }
    }

}

namespace Etap0
{
    internal class Program
    {

        public static void Main(string[] args)
        {
            Kalkulator kalkulator = new Kalkulator();
            Console.WriteLine(kalkulator.Dodawanie(1,2));
            Console.WriteLine(kalkulator.Dodawanie(1,2,3));
            Console.WriteLine(kalkulator.Dodawanie(1,2,3,4));
            Console.WriteLine(kalkulator.Potegowanie(2,15));
            Console.WriteLine(kalkulator.Dzielene(3,5));
            Console.WriteLine(kalkulator.Dodawanie(1,2,3,4,5,6));
            
        }
    }
}