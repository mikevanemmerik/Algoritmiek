using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3b
{
    public class Number : Expression {
	
	public Number(int number)
	{
	}

	override public int evaluate() {
		throw new Exception("Not implemented, yet");
	}
}
}
