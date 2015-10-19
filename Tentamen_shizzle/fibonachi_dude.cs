using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentamen_shizzle
{
    class fibonachi_dude
    {

        public fibonachi_dude()
        {
           Iteratief(2000);

            Recursief(0,1, 1, 2000);
        }

        private void Iteratief(int max)
        {
            int a = 0;
            int b = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < max; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
                Console.WriteLine("> " + a);
            }
        }

        private void Recursief(int a, int b, int counter, int number)
        {
            Console.WriteLine(a);
            if (counter < number) 
                Recursief(b, a + b, counter + 1, number);
        }
    }
}
