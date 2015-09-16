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
            QuickSortRecursive(numbers, 0, numbers.Length - 1);
            sw.Stop();
            Console.WriteLine("QuickSortz3 - 1: " + sw.Elapsed + " - Swaps: " + swaps + " vergelijking: " + vergelijkingen);
            //
            sw.Reset();
            swaps = vergelijkingen = 0;
            sw.Start();
            QuickSortRecursive(numbers, 0, numbers.Length - 1);
            sw.Stop();
            Console.WriteLine("QuickSortz3 - 2: " + sw.Elapsed + " - Swaps: " + swaps + " vergelijking: " + vergelijkingen);
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
            int middle = (left + right) / 2;

            int pivot = calcPivot(numbers[left], numbers[middle], numbers[right]);
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

        private int calcPivot(int left, int middle, int right)
        {
            int pivot = 0;
            vergelijkingen++;
            if (left > middle)
            {
                vergelijkingen++;
                if (left > right)
                {
                    vergelijkingen++;
                    if (right > middle)
                    {
                        pivot = right;
                    }
                    else
                    {
                        pivot = middle;
                    }
                }
                else
                {
                    pivot =  left;
                }
            }
            else
            {
                vergelijkingen++;
                if (left < right)
                {
                    vergelijkingen++;
                    if (right < middle)
                    {
                        pivot =  right;
                    }
                    else
                    {
                        pivot = middle;
                    }
                }
                else
                {
                    pivot = left;
                }
            }

            return pivot;
        }
    }
}
