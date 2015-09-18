using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3b
{
    public class Operand : Expression
    {

        private char ope;
        private Expression l, r;

        public Operand(char operand, Expression left, Expression right)
        {

            l = left;
            r = right;
            ope = operand;
        }


        override public int evaluate()
        {
            int sum = 0;
            if(ope == '+')
                sum = l.evaluate() + r.evaluate();
            else if(ope == '*')
                sum = l.evaluate() * r.evaluate();
            return sum;
        }

        public override string ToString()
        {
            return string.Format("({0}{1}{2})", l.ToString(), ope.ToString(), r.ToString());
        }
    }
}
