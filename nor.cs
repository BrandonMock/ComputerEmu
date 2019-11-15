using System;
using Logic;

namespace Logic
{
	class NOR
	{
		bool[] I = new bool[5];
		bool O;

		 public void setI(int index, bool val){
			I[index] = val;
			var n1 = new NAND();
			var o1 = new OR();
	
			o1.setI(1,I[1]);
			o1.setI(2,I[2]);
			n1.setI(1,o1.getO());
			n1.setI(2,o1.getO());
			O = n1.getO();
		}

		public bool getI(int i){
			return(I[i]);
		}	
	
		public bool getO(){
			return O;
		}
	}
}
