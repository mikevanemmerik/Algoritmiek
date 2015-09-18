using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3b
{
    public class Number : Expression {
	
    private int num;

	public Number(int number)
	{
        num = number;
	}

	override public int evaluate() {
        return num;
	}

    public override string ToString()
    {
        return num.ToString();
    }
}
}
