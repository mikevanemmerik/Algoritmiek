using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4
{
    public class BSTNode
    {
        public int number;

        public BSTNode left;
        public BSTNode right;
        public BSTNode parent;

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
                {
                    this.left = new BSTNode(number);
                    this.left.parent = this;
                }
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
                {
                    this.right = new BSTNode(number);
                    this.right.parent = this;
                }
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

        public BSTNode minNode()
        {
            if (left == null)
                return this;
            return left.minNode();
        }

        public BSTNode maxNode()
        {
            if (right == null)
                return this;
            return right.maxNode();
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

            Console.Write(" - " + number);
            if (left != null)
                left.print();



            if (right != null)
                right.print();

        }

        public void printInOrder()
        {


            if (left != null)
                left.printInOrder();

            Console.Write(" - " + number);

            if (right != null)
                right.printInOrder();

        }

        public void printPreOrder()
        {

            Console.Write(" - " + number);
            if (left != null)
                left.printPreOrder();



            if (right != null)
                right.printPreOrder();

        }

        public void printPostOrder()
        {


            if (left != null)
                left.printPostOrder();



            if (right != null)
                right.printPostOrder();
            Console.Write(" - " + number);
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
            y.parent = x.parent;
            x.right = T2;
            if (T2 != null)
                T2.parent = x;
            x.parent = y;

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
            y.parent = x.parent;
            x.left = T2;
            if(T2 != null)
                T2.parent = x;
            x.parent = y;

            return y;
        }




        public BSTNode getInOrderNext()
        {
            BSTNode result = this;

            if (right != null)
            {
                result = right;
                while (result.left != null)
                    result = result.left;
                return result;
            }
            // left child
            if (parent != null && parent.left == this)
                return parent;
            // right child
            while (result.parent != null && result.parent.left == result)
                result = result.parent;

            if (result != null)
                return result.parent;
            else
                return null;

        }

        public BSTNode getPreOrderNext()
        {
            BSTNode result = this;

            if (left != null)
            {
                return left;
            }

            while (result.parent != null)
            {
                if (result.right != null)
                    return result.right;
                result = result.parent;
            }



            if (result != null && result.right != null)
                return result.right;
            else
                return null;

        }
        public BSTNode getPostOrderNext()
        {
            BSTNode result = this;

            //1: meest linkse, 
            //2: Meest linkse van current zijn (misschien) parent
            //3: VANUITGAAN?: Als parent.right == this? return this


            //while (result.left != null)
            //{
            //    result = result.left;
            //    if (result.left == null)
            //        return result;
            //}
            //

            //if(result.parent == this)
            //{

            //}

            //
            if (result.parent != null )
            {
                result = result.parent;
                if (result.right != null && result.right != this){
                    result = result.right;
                    while (result.left != null)
                    {
                        result = result.left;
                        if (result.left == null)
                            return result;
                    }
                }
            }
            return result;
            //

        }
    }
}
