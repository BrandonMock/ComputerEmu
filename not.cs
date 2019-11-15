using System;
using Logic;

namespace Logic
{
	class NOT
	{
		bool I;
		bool O;

		public void setI(bool val){
			I = val;
			var n1 = new NAND();
			n1.setI(1,I);
			n1.setI(2,I);
			O = n1.getO();
		}
		
		public bool getI(){
			return(I);
		}
		
		public bool getO(){
			return O;
		}
	}
}
