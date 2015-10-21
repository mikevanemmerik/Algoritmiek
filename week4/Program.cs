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

            var rr = new Random(23123);
            for (int i = 1; i <= 8; i++)
            {
                int j = rr.Next(1, 20);
                tree.insertAvl(j);
                //tree.prettyprint();
                //Console.WriteLine("\n====================" + tree.isAvlBalanced() + "======================\n");
            }

            Console.WriteLine("\n==========================================\n");

            bool shit = tree.isAvlBalanced();

            Console.WriteLine("LAWL: " + shit);
           // tree.root.left = tree.root.left.rotateRight();
            tree.prettyprint();

            tree.getPostOrderNext();

            Console.ReadKey();
        }
    }
}
