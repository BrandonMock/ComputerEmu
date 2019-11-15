using System;
using Logic; 
using Latches;
using Computer;

namespace Computer
{
	class Alu
	{
		public void Calculate(Register AX, Register BX,bool SubtractFlag, bool clock){
			var FA = new fullAdder();
			FA.setCarryIn(SubtractFlag);
			for(int i=0; i<8; i++){
				var x1 = new XOR();
				x1.setI(1,SubtractFlag);
				x1.setI(2,BX.getBit(i));
				FA.setI(1,AX.getBit(i));
				FA.setI(2,x1.getO());
				FA.Calculate();
				FA.setCarryIn(FA.getCarryOut());
				AX.setBit(i,FA.getO(),clock);
			}
		}
	}
}
