using System;
using Logic; 
using Latches;
using Computer;

namespace Computer
{
	class Alu
	{
		ComputerSystem CS = new ComputerSystem();
		Register data = new Register();
		public void Calculate(Register AX, Register BX,bool SubtractFlag, bool clock){
			var FA = new fullAdder();
			data.reset();
			FA.setCarryIn(SubtractFlag);
			for(int i=0; i<CS.wordsize; i++){
				var x1 = new XOR();
				x1.setI(1,SubtractFlag);
				x1.setI(2,BX.getBit(i));
				FA.setI(1,AX.getBit(i));
				FA.setI(2,x1.getO());
				FA.Calculate();
				FA.setCarryIn(FA.getCarryOut());
				data.setBit(i,FA.getO(),clock);
			}
		}
		public string getByte(){
			return data.getByte();
		}

		public LatchArray outputData(LatchArray db, bool clock){
			return data.outputData(db, clock);
		}

		public void inputData(LatchArray db, bool clock){
			data.inputData(db,clock);
		}
		
		public void shiftData(LatchArray db, bool clock)
		{
			db.reset();
			for(int i=0; i<CS.wordsize; i++){
				db.setBit(i,data.getBit(i),clock);
			}
		}



	}
}
