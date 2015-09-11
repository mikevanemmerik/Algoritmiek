using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2
{
    class MergeSort
    {
        Stopwatch sw = new Stopwatch();

        int swaps = 0;
        int vergelijkingen = 0;

        public MergeSort()
        {
            int[] numbers = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                numbers[i] = new Random(Guid.NewGuid().GetHashCode()).Next(1, 5000);
            }

            sw.Start();
           // MergeSort_Recursive(numbers, 0, numbers.Length - 1);
            SortMerge(numbers, 0, numbers.Length -1);
            
            
            sw.Stop();
            Console.WriteLine("Mergesort - 1: " + sw.Elapsed + " - Swaps: " + swaps + " vergelijking: " + vergelijkingen);
            //
            sw.Reset();
            swaps = vergelijkingen = 0;
            sw.Start();
            SortMerge(numbers, 0, numbers.Length - 1);

            sw.Stop();
            Console.WriteLine("Mergesort - 2: " + sw.Elapsed + " - Swaps: " + swaps + " vergelijking: " + vergelijkingen);
        }



        public void MainMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[1000];
            int i, eol, num, pos;

            eol = (mid - 1);
            pos = left;
            num = (right - left + 1);

            while ((left <= eol) && (mid <= right))
            {
                vergelijkingen++;
                if (numbers[left] <= numbers[mid])
                    temp[pos++] = numbers[left++];
                else
                    temp[pos++] = numbers[mid++];
                // swaps++;
            }

            while (left <= eol)
            {
                temp[pos++] = numbers[left++];
                // swaps++;
            }
                

            while (mid <= right)
            {
                temp[pos++] = numbers[mid++];
                // swaps++;
            }
                

            for (i = 0; i < num; i++)
            {
                numbers[right] = temp[right];
                swaps++;
                right--;
            }
        }

        public void SortMerge(int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                SortMerge(numbers, left, mid);
                SortMerge(numbers, (mid + 1), right);

                MainMerge(numbers, left, (mid + 1), right);
            }
        }
        
    }
}
