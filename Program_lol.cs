using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgEnData
{
    class Program
    {
        static void Main(string[] args)
        {
            driehoek();
            Fibonacci(0, 1, 1, 20);
            Console.ReadKey();
        }


        static void Fibonacci(int a, int b, int counter, int number)
        {
            Console.WriteLine(a);
            if (counter < number)
                Fibonacci(b, a + b, counter + 1, number);
        }



        static void driehoek()
        {
            ita(10);
            Console.WriteLine();
            Console.Write("REC: n is " + rec(10));
            Console.WriteLine("FLAT: n is " + flat(7));
        }

        static void ita(int n)
        {
            int getal = 0;
            Console.Write("n is ");
            for (int i = 1; i <= n; i++)
            {
                Console.Write(getal+ ", ");
                getal = getal + i;
                
            }
        }


        static int rec(int i)
        {
            if (i > 0)
            {
                return i + rec(i - 1);
                //
               
            }
            return 0;
        }

        static float flat(int n)
        {
            
            return 0.5f * n * (n + 1);
        }
    }
}
