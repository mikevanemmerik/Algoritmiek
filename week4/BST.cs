using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4
{
    public class BST
    {
        public BSTNode root;

        /**
         * Inserts the value into the binary search tree
         */
        public void insert(int number)
        {
            if (root == null)
            {
                root = new BSTNode(number);
            }
            else
            {
                root.insert(number);
            }
        }

        /**
         * Returns true if the number is present as a node in the tree
         */
        public bool exists(int number)
        {
            return root.exists(number);
        }

        /**
         * Returns the smallest value in the tree (or -1 if tree is empty)
         */
        public int min()
        {
            if (root == null) return -1;
            return root.min();
        }

        /**
         * Returns the largest value in the tree (or -1 if tree is empty)
         */
        public int max()
        {
            if (root == null) return -1;
            return root.max();
        }

        /**
         * Returns how many levels deep the deepest level in the tree is
         * (the empty tree is 0 levels deep, the tree with only one root node is 1 deep)
         * @return
         */
        public int depth()
        {
            if (root == null) return -1;
            return root.depth();
        }

        /**
         * Returns the amount of values in the tree
         * @return
         */
        public int count()
        {
            if (root == null) return 0;
            return root.count();
        }

        /**
         * Print all the values in the tree in order
         */
        public void print()
        {
            if(root != null) root.print();
            Console.Write("\n");
        }

        /**
         * Print all values that lie between min and max in order (inclusive)
         */
        public void printInRange(int min, int max)
        {
            if(root != null) root.printInRange(min, max);
            Console.Write("\n");
        }

        /**
         * Delete a number from the tree (if it exists)
         */
        public void delete(int number)
        {
            root = root.delete(number);
        }

        public void prettyprint()
        {
            if (root != null)
            {
                root.prettyprint("@", " ");
            }
        }


    }
}
