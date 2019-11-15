using System;
using Logic;

namespace Logic
{
	class OR
	{
		bool[] I = new bool[5];
		bool O;

		public void setI(int index, bool val){
			I[index] = val;
			var n1 = new NAND();
			var n2 = new NAND();
			var n3 = new NAND();
			
			n1.setI(1,I[1]);
			n1.setI(2,I[1]);
			n2.setI(1,I[2]);
			n2.setI(2,I[2]);
			n3.setI(1,n1.getO());
			n3.setI(2,n2.getO());
			O = n3.getO();
		}	
		
		public bool getI(int i){
			return(I[i]);
		}
		
		public bool getO(){
			return O;
		}
	}
}
