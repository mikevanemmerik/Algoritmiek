using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4
{
    public class BSTNode
    {
        private int number;

        public BSTNode left;
        public BSTNode right;

        public BSTNode(int number)
        {
            this.number = number;
        }

        public void insert(int number)
        {
            if (number < this.number)
            {
                // Smaller value, insert it into the left subtree
                if (this.left == null)
                    this.left = new BSTNode(number);
                else
                    this.left.insert(number);
            }
            else
            {
                // Larger value, insert it in the right subtree
                if (this.right == null)
                    this.right = new BSTNode(number);
                else
                    this.right.insert(number);
            }
        }

        public int count()
        {
            return 1 + (left != null ? left.count() : 0) + (right != null ? right.count() : 0);
        }

        public int min()
        {
            if (left == null) return this.number;
            return left.min();
        }

        public int max()
        {
            if (right == null) return this.number;
            return right.max();
        }

        public int depth()
        {
            int ret = 1;
            if (left != null)
            {
                if (right != null)
                {
                    if (left.depth() > right.depth())
                        return left.depth() + 1;
                    else
                        return right.depth() + 1;
                }
                else
                {
                    ret += left.depth();
                }

            }
            else if (right != null)
            {
                ret += right.depth();
            }
            return ret;
        }

        public void print()
        {
            if (left != null)
                left.print();

            Console.Write(" - " + number);

            if (right != null)
                right.print();

        }


        public void printInRange(int min, int max)
        {
            if (left != null && number > min)
                left.printInRange(min, max);

            if (number > min && number < max)
                Console.Write(" - " + number);

            if (right != null && number < max)
                right.printInRange(min, max);
        }

        public BSTNode delete(int number)
        {
            if (number < this.number)
            {
                if (this.left != null)
                {
                    this.left = this.left.delete(number);
                }
                return this;
            }
            else if (number > this.number)
            {
                if (this.right != null)
                {
                    this.right = this.right.delete(number);
                }
                return this;
            }
            else
            {
                if (this.left == null)
                {
                    return this.right;
                }
                else if (this.right == null)
                {
                    return this.left;
                }
                else
                {
                    this.number = this.right.min();
                    this.right = right.delete(this.number);
                    return this;
                }
            }
        }

        public bool exists(int number)
        {
            bool a = false;



            if (this.number == number)
                a = true;

            if (left != null)
                a = a | (left.exists(number));

            if (right != null)
                if (right.exists(number))
                    return true;

            return false;
        }


        public void prettyprint(String firstPrefix, String prefix)
        {
            Console.WriteLine(firstPrefix + number);

            if (right == null)
            {
                Console.WriteLine(prefix + "├── .");
            }
            else
            {
                right.prettyprint(prefix + "├── ", prefix + "|   ");
            }

            if (left == null)
            {
                Console.WriteLine(prefix + "└── .");
            }
            else
            {
                left.prettyprint(prefix + "└── ", prefix + "    ");
            }
        }

        public bool isAvlBalanced()
        {
            if (Math.Abs(left.depth() - right.depth()) > 1)
                return false;
            return true;
        }

        public BSTNode rotateLeft()
        {
            if(right == null)
            {
                return this;
            }
            BSTNode x = this;
            BSTNode y = this.right;
            
            BSTNode T2 = this.left;
 
            // Rotate
            y.left = x;
            this.right = T2;
 
            return y;
        }


        public BSTNode rotateRight()
        {
            return this;
        }



    }
}
