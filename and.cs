using System;
using NAND;

namespace AND
{
	class AND{
		bool[] I = new bool[8];
		bool O;
	
		public void setI(int index, bool val){
			I[index] = val;
			NAND.NAND n1 = new NAND.NAND();
			NAND.NAND n2 = new NAND.NAND();
		
			n1.setI(1,I[1]);
			n1.setI(2,I[2]);
			n2.setI(1,n1.getO());
			n2.setI(2,n1.getO());
			O = n2.getO();
		}
			
		public bool getI(int i){
			return(I[i]);
		}
			
		public bool getO(){
			return O;
		}
	}
}
