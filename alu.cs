using System;
using fullAdder;
using XOR;
using Register;

namespace Alu
{
	class Alu
	{
		public void Calculate(Register.Register AX, Register.Register BX,bool SubtractFlag, bool clock){
			fullAdder.fullAdder FA = new fullAdder.fullAdder();
			FA.setCarryIn(SubtractFlag);
			for(int i=0; i<8; i++){
				XOR.XOR x1 = new XOR.XOR();
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
