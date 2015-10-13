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

        public BSTNode insert(int number)
        {
            if (number < this.number)
            {
                // Smaller value, insert it into the left subtree
                if (this.left == null)
                    this.left = new BSTNode(number);
                else
                    this.left = this.left.insert(number);
            }
            else
            {
                // Larger value, insert it in the right subtree
                if (this.right == null)
                    this.right = new BSTNode(number);
                else
                    this.right = this.right.insert(number);
            }
            
           
            return this;
        }

        public BSTNode insertAvl(int number)
        {
            if (number < this.number)
            {
                // Smaller value, insert it into the left subtree
                if (this.left == null)
                    this.left = new BSTNode(number);
                else
                    this.left = this.left.insertAvl(number);

                if (!isAvlBalanced())
                {
                    //Linkerkind is rechts zwaarder (extra rotatie)
                    if (height(this.left.left) >= height(this.left.right))
                    {
                        return this.rotateRight();
                    }
                    else
                    {
                        this.left = this.left.rotateLeft();
                        return this.rotateRight();
                    }
                }
            }
            else
            {
                // Larger value, insert it in the right subtree
                if (this.right == null)
                    this.right = new BSTNode(number);
                else
                    this.right = this.right.insertAvl(number);

                if (!isAvlBalanced())
                {
                    //Het rechterkind is links zwaarder (extra rotatie)
                    if (height(this.right.right) >= height(this.right.left))
                    {
                        return this.rotateLeft();
                    }
                    else
                    {
                        this.right = this.right.rotateRight();
                        return this.rotateLeft();
                    }
                }
            }


            return this;
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
            else 
                if (right != null)
            {
                ret += right.depth();
            }
            return ret;
        }

        public int height(BSTNode cur)
        {
            if (cur == null)
            {
                return -1;
            }
            if (cur.left == null && cur.right == null)
            {
                return 0;
            }
            else if (cur.left == null)
            {
                return 1 + height(cur.right);
            }
            else if (cur.right == null)
            {
                return 1 + height(cur.left);
            }
            else
            {
                return 1 + Math.Max(height(cur.left), height(cur.right));
            }
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
            bool returnVal = true;

            int leftDepth = 0, rightDepth = 0;

            if (this.left != null)
            {
                this.left.isAvlBalanced();
                leftDepth = this.left.depth();
            }

            if (this.right != null)
            {
                this.right.isAvlBalanced();
                rightDepth = this.right.depth();
            }

            if (Math.Abs(leftDepth - rightDepth) > 1) returnVal = false;

            return returnVal;
        }

        public BSTNode rotateLeft()
        {
            if (right == null)
            {
                return this;
            }
            BSTNode x = this;
            BSTNode y = this.right;

            BSTNode T2 = y.left;

            // Rotate
            y.left = x;
            x.right = T2;

            return y;
        }


        public BSTNode rotateRight()
        {
            if (left == null)
            {
                return this;
            }

            BSTNode x = this;
            BSTNode y = this.left;

            BSTNode T2 = y.right;

            // Rotate
            y.right = x;
            x.left = T2;

            return y;
        }



    }
}
