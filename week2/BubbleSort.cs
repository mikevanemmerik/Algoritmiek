using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    public class BubbleSort
    {
        Stopwatch sw = new Stopwatch();

        int swaps = 0;
        int vergelijkingen = 0;
        public BubbleSort()
        {
            int[] numbers = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                numbers[i] = new Random(Guid.NewGuid().GetHashCode()).Next(1, 5000);
            }

            sw.Start();
            //Do shizzle 2
            bubs(numbers);
            sw.Stop();
            Console.WriteLine("bubblesort - 1: " + sw.Elapsed + " - Swaps: " + swaps + " vergelijking: " + vergelijkingen);
            //
            sw.Reset();
            swaps = vergelijkingen = 0;
            sw.Start();
            //Do shizzle 2
            bubs(numbers);
            sw.Stop();
            Console.WriteLine("bubblesort - 2: " + sw.Elapsed + " - Swaps: " + swaps + " vergelijking: " + vergelijkingen);
        }

        public int[] bubs(int[] arr)
        {
            int temp = 0;

            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                        swaps++;
                        vergelijkingen++;
                    }
                }
            }
            return arr;
        }


    }
}
