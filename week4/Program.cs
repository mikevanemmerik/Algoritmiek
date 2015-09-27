using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WindowHeight = 500;
            //this.Height = 500;
            BST tree = new BST();
            for (int i = 1; i <= 100; i++)
            {

                tree.insertAvl(i);
            }

            Console.WriteLine("\n==========================================\n");

            bool shit = tree.isAvlBalanced();

            Console.WriteLine("LAWL: " + shit);
           // tree.root.left = tree.root.left.rotateRight();
            tree.prettyprint();

            Console.ReadKey();
        }
    }
}
