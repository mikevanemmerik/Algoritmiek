using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3b
{
    public class Operand : Expression {

	public Operand(char operand, Expression left, Expression right) {
		
	}


	override public int evaluate() {
		throw new Exception("Not implemented, yet");
	}

    public override string ToString()
    {
        return "";
    }
}
}
