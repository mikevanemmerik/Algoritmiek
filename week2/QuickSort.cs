using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    class QuickSort
    {
        Stopwatch sw = new Stopwatch();

        int swaps = 0;
        int vergelijkingen = 0;

        public QuickSort()
        {
            int[] numbers = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                numbers[i] = new Random(Guid.NewGuid().GetHashCode()).Next(1, 5000);
            }

            sw.Start();
            QuickSortRecursive(numbers,0,numbers.Length-1);
            sw.Stop();
            Console.WriteLine("QuickSortz 1: " + sw.Elapsed + " - Swaps: " + swaps + " vergelijking: " + vergelijkingen);
            //
            sw.Reset();
            swaps = vergelijkingen = 0;
            sw.Start();
            QuickSortRecursive(numbers, 0, numbers.Length-1);
            sw.Stop();
            Console.WriteLine("QuickSortz 2: " + sw.Elapsed + " - Swaps: " + swaps + " vergelijking: " + vergelijkingen);
        }

        public void QuickSortRecursive(int[] arr, int left, int right)
        {
            if (left < right)
            {
                vergelijkingen++;
                int pivot = Partition(arr, left, right);

                vergelijkingen++;
                vergelijkingen++;
                if (pivot > 1)
                    QuickSortRecursive(arr, left, pivot - 1);
                if (pivot + 1 < right)
                    QuickSortRecursive(arr, pivot + 1, right);
            }

            
        }
        private int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            while (true)
            {
                vergelijkingen++;
                while (numbers[left] < pivot)
                {
                    left++;
                    vergelijkingen++;
                }
                while (numbers[right] > pivot)
                {
                    right--;
                    vergelijkingen++;
                }

                /* to allow equal numbers */
                if (numbers[right] == pivot && numbers[left] == pivot)
                {
                    vergelijkingen++;
                    left++;
                }

                if (left < right)
                {
                    vergelijkingen++;
                    int temp = numbers[right];
                    swaps++;
                    numbers[right] = numbers[left];
                    numbers[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        private void doit()
        {

        }
    }
}
