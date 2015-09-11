using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    class QuickSOrt3
    {

        Stopwatch sw = new Stopwatch();

        int swaps = 0;
        int vergelijkingen = 0;

        public QuickSOrt3()
        {
            int[] numbers = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                numbers[i] = new Random(Guid.NewGuid().GetHashCode()).Next(1, 5000);
            }

            sw.Start();
            //QuickSortRecursive(numbers, 0, numbers.Length - 1);
            sw.Stop();
            Console.WriteLine("QuickSortz3 - 1: " + sw.Elapsed + " - Swaps: " + swaps + " vergelijking: " + vergelijkingen);
            //
            sw.Reset();
            swaps = vergelijkingen = 0;
            sw.Start();
            //QuickSortRecursive(numbers, 0, numbers.Length - 1);
            sw.Stop();
            Console.WriteLine("QuickSortz3 - 2: " + sw.Elapsed + " - Swaps: " + swaps + " vergelijking: " + vergelijkingen);
        }
    }
}
