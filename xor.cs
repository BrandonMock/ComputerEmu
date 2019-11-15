using System;
using NAND;

namespace XOR
{
	class XOR
	{
		bool[] I = new bool[5];
		bool O;

		public void setI(int index, bool val){
			I[index] = val;
		
			NAND.NAND n1 = new NAND.NAND();
			NAND.NAND n2 = new NAND.NAND();
			NAND.NAND n3 = new NAND.NAND();
			NAND.NAND n4 = new NAND.NAND();

			n1.setI(1,I[1]);
			n1.setI(2,I[2]);
			n2.setI(1,I[1]);
			n2.setI(2,n1.getO());
			n3.setI(1,I[2]);
			n3.setI(2,n1.getO());
			n4.setI(1,n2.getO());
			n4.setI(2,n3.getO());
			O = n4.getO();
		}
		
		public bool getI(int i){
			return(I[i]);
		}

		public bool getO(){
			return O;
		}
	}
}
