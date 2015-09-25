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
            for (int i = 1; i < 50; i++)
            {
                tree.insertAvl(i);
            }
            /*
            tree.insert(50);
            tree.insert(60);
            tree.insert(47);
            tree.insert(11);
            tree.insert(12);
            tree.insert(53);
            tree.insert(2);
            tree.insert(7);
            tree.insert(94);
            tree.insert(24);
            tree.insert(24);
            tree.insert(71);
            tree.insert(30);
            tree.insert(49);*/
            tree.prettyprint();

            Console.WriteLine("\n==========================================\n");

            bool shit = tree.isAvlBalanced();

            Console.WriteLine("LAWL: " + shit);
           // tree.root.left = tree.root.left.rotateRight();


            tree.prettyprint();

            Console.ReadKey();
        }
    }
}
