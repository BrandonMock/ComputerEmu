using System;
using System.Threading;
using Latches;
using Computer;
using Displays;
namespace Computer
{
	class Program
	{
		static void Main(string[] args) {
			var CLK = new Clock();
			var ram = new RAM();
			var alu = new Alu();
			var DB  = new Register();
			var AX  = new Register();
			var BX  = new Register();
			var CX  = new Register();
			var DX  = new Register();
			double 	 tick=0;
			LedArray  databus;
			LedArray  axString;
			LedArray  bxString;
			bool 	 subtractFlag = false;
		
			DB.reset();
			AX.reset();
			BX.reset();
		
			BX.setValue("00000001");
			
			AX.setOutput();
			BX.setInput();
			AX.setEnable(true);
			BX.setEnable(false);
			CLK.setManual(false);
			
			while (tick<=Math.Pow(2,8)-1){
				tick = CLK.getNextClock();
				if(CLK.getSignal()){
					DB = (Register)AX.outputData(DB, CLK.getSignal());
					DB = (Register)BX.outputData(DB, CLK.getSignal());
					AX.inputData(DB, CLK.getSignal());
					BX.inputData(DB, CLK.getSignal());
					alu.Calculate(AX,BX,subtractFlag, CLK.getSignal());
					Console.Clear();			
					databus =  new LedArray(DB.getByte(), ConsoleColor.Green, ConsoleColor.Black);
					axString = new LedArray(AX.getByte(), ConsoleColor.Green, ConsoleColor.Black);
					bxString = new LedArray(BX.getByte(), ConsoleColor.Green, ConsoleColor.Black);
					Console.Write("clock:{0}  |  clksignal:{1}  ",tick.ToString("00000000"),CLK.getSignal());
					Console.Write("\n BUS: ");
					databus.display();
					Console.Write("\n  AX: ");
					axString.display();
					Console.Write("\n  BX: ");
					bxString.display();
					Console.Write("\n");
					Thread.Sleep(200);
				}else{
					DB.reset();
				}
			}
		}
	}
}
