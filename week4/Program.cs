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
            BST tree = new BST();
            tree.insert(50);
            tree.insert(2);
            tree.insert(7);
            tree.insert(94);
            tree.insert(24);
            tree.insert(24);
            tree.insert(71);
            tree.insert(30);
            tree.insert(49);
            tree.prettyprint();

            Console.WriteLine("\n==========================================\n");
            tree.root.right = tree.root.left.rotateLeft();

            tree.prettyprint();

            Console.ReadKey();
        }
    }
}
