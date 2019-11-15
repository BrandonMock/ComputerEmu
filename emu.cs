using System;

namespace computer
{
	class Program
	{
		static void Main(string[] args) {
			Clock.Clock 	CLK = new Clock.Clock();
			RAM.RAM	 	ram = new RAM.RAM();
			Alu.Alu	 	alu = new Alu.Alu();
			Register.Register DB = new Register.Register();
			Register.Register AX = new Register.Register();
			Register.Register BX = new Register.Register();
			Register.Register CX = new Register.Register();
			Register.Register DX = new Register.Register();
			double 	 tick=0;
			string   databus;
			string	 axString;
			string	 bxString;
			bool 	 subtractFlag = false;
		
			DB.reset();
			AX.reset();
			BX.reset();
		
			BX.setValue("00000001");
			
			bxString = BX.getByte();
			Console.WriteLine("BX:{0}  \n",bxString );
		
			AX.setOutput();
			BX.setInput();
			AX.setEnable(true);
			BX.setEnable(false);
			CLK.setManual(false);
			
			while (tick<=Math.Pow(2,8)-1){
				tick = CLK.getNextClock();
				if(CLK.getSignal()){
					DB = (Register.Register)AX.outputData(DB, CLK.getSignal());
					DB = (Register.Register)BX.outputData(DB, CLK.getSignal());
					AX.inputData(DB, CLK.getSignal());
					BX.inputData(DB, CLK.getSignal());
					alu.Calculate(AX,BX,subtractFlag, CLK.getSignal());
					
					databus = DB.getByte();
					axString = AX.getByte();
					bxString = BX.getByte();
					Console.WriteLine("clock:{0}  |  clksignal:{1}  |  bus:{2}  |  AX:{3}  |  BX:{4}  | ",tick,CLK.getSignal(), databus, axString, bxString );
				}else{
					DB.reset();
				}
			}
		}
	}
}
