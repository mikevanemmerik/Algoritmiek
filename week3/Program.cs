using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3
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
            bool b1 = tree.exists(30);
            bool b2 = tree.exists(1000);
            bool b3 = tree.exists(123123);
            bool b4 = tree.exists(71);
            Console.WriteLine("Count(9): " + tree.count()); // Should be 9
            Console.WriteLine("Min(2): " + tree.min()); // Should be 2
            Console.WriteLine("Max(94): " + tree.max()); // Should be 94
            Console.WriteLine("Depth(7): " + tree.depth()); // Should be 7
            tree.print(); // Prints the values in order
            tree.printInRange(20,31);

            tree.delete(47); // test for value not in tree
            tree.delete(51); // test for value not in tree
            tree.delete(50);
            tree.delete(2);
            tree.delete(7);
            tree.delete(94);
            tree.delete(24);
            tree.delete(24);
            tree.delete(71);
            tree.delete(30);
            tree.delete(49);
            
            Console.WriteLine("Count(0): " + tree.count()); // Should be 0
            Console.WriteLine("Min(-1): " + tree.min()); // Should be -1
            Console.WriteLine("Max(-1): " + tree.max()); // Should be -1
            Console.WriteLine("Depth(0): " + tree.depth()); // Should be 0
            tree.print(); // Prints the values in order
            Console.ReadKey();
        }
    }
}
