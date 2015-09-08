using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ALG2
{
    class Program
    {
        static void Main(string[] args)
        {
            Driehoek(100);
            Console.WriteLine();
            Fibonacci(15);
            Console.WriteLine();
            omgedraaidRec("Paul");
            Console.WriteLine();
            Console.WriteLine(omgedraaidPal("deelkoortsmeetsysteemstrookleed"));
            Console.ReadKey();
        }

        static void Fibonacci(int n)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(fiboIte(n));
            sw.Stop();
            Console.WriteLine("iterative Elapsed={0}", sw.Elapsed);
            sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(fiboRec(n));
            sw.Stop();
            Console.WriteLine("recursive Elapsed={0}", sw.Elapsed);
        }

        static void omgedraaidRec(string n)
        {
            if (n.Length > 0)
            {
                Console.Write(n[n.Length - 1]);
                n = n.Remove(n.Length - 1);
                omgedraaidRec(n);
            }

        }

        static bool omgedraaidPal(string n)
        {
            n = n.ToLower();
            if (n.Length >= 2)
            {
                if (n[0] == n[n.Length - 1])
                {
                    n = n.Remove(0,1);
                    n = n.Remove(n.Length - 1);
                    return omgedraaidPal(n);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }




        static int fiboRec(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return fiboRec(n - 1) + fiboRec(n - 2);
        }

        static int fiboIte(int n)
        {
            if(n == 0)
                return 0;
            else if (n == 1)
                return 1;
            int prev2 = 0;
            int prev = 1;
            int result = 0;
            for (int i = 2; i <= n; i++)
			{
                result = prev + prev2;
                prev2 = prev;
                prev = result;
			}
            return result;
        }

        static void Driehoek(int n)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(iterative(n));
            sw.Stop();
            Console.WriteLine("iterative Elapsed={0}", sw.Elapsed);
            sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(recursive(n));
            sw.Stop();
            Console.WriteLine("recursive Elapsed={0}", sw.Elapsed);
            sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(functional(n));
            sw.Stop();
            Console.WriteLine("functional Elapsed={0}", sw.Elapsed);
            Console.WriteLine();
        }
        static int iterative(int n)
        {
            int getal = 0;
            for (int i = 1; i <= n; i++)
            {
                getal = getal + i;
            }
            return getal;
        }

        static int recursive(int n)
        {
            if (n > 0)
            {
                n = n + recursive(n - 1);
            }
            
            return n;
        }
        static int functional(int n)
        {
            n = (n / 2) * (n + 1);
            return n;
        }
    }
}
