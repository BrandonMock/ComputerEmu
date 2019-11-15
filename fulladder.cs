using System;
using Logic; 
using Computer;

namespace Computer 
{
	class fullAdder
	{
		bool carryIn;
		bool[] I = new bool[2];
		bool O;
		bool carryOut;
	
		public void setCarryIn(bool val){
			carryIn = val;
		}
		public bool getCarryIn(){
			return(carryIn);
		}
		public void setI(int i, bool val){
			I[i-1]=val;
		}
		public bool getI(int i){
			return(I[i-1]);
		}
		public void setO(bool val){
			O=val;
		}
		public bool getO(){
			return(O);
		}
		public void setCarryOut(bool val){
			carryOut=val;
		}
		public bool getCarryOut(){
			return(carryOut);
		}

		public void Calculate(){
			var a1 = new AND();
			var a2 = new AND();
			var x1 = new XOR();
			var x2 = new XOR();
			var o1 = new OR();
			
			a1.setI(1,getI(1));
			a1.setI(2,getI(2));
			x1.setI(1,getI(1));
			x1.setI(2,getI(2));
			x2.setI(1,x1.getO());
			x2.setI(2,getCarryIn());
			a2.setI(1,x1.getO());
			a2.setI(2,getCarryIn());
			setO(x2.getO());
			o1.setI(1,a1.getO());
			o1.setI(2,a2.getO());
			setCarryOut(o1.getO());	
		}
	}
}
