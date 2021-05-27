using System;
using System.Threading;
using Latches;
using Computer;
using Displays;
namespace Computer
{
	class Program
	{
		public static bool itob(int i){
			if(i==1){
				return true;
			}
			return false;
		}

		static void Main(string[] args) {

			var CS = new ComputerSystem();
			var CLK = new Clock();
			var ram = new RAM();
			var alu = new Alu();
			var DB  = new Register();
			var AX  = new Register();
			var BX  = new Register();
			var CX  = new Register();
			var DX  = new Register();
			double 	  tick=0;
			LedArray  databus;
			LedArray  alubus;
			LedArray  axString;
			LedArray  bxString;
			LedArray  cxString;
			LedArray  dxString;
			bool 	  subtractFlag = false;
	
			DB.reset();
			AX.reset();
			BX.reset();
			
			var tempBX = new string('0',(int)CS.wordsize-1);	
			Console.Write("TempBXi: {0}\n", tempBX);
			BX.setValue(String.Concat(tempBX,"1"));
			AX.setInput();
			BX.setInput();
			CX.setInput();
			DX.setOutput();
			AX.setEnable(false);
			BX.setEnable(false);
			CX.setEnable(false);
			DX.setEnable(false);
			CLK.setManual(false);
			
			while (tick<=Math.Pow(2,CS.wordsize)-1){
				tick = CLK.getNextClock();
				if(CLK.getSignal()){
					//If Register is set for output, get the data from Regiter and put on BUS
					DB = (Register)AX.outputData(DB, CLK.getSignal());
					DB = (Register)BX.outputData(DB, CLK.getSignal());
					DB = (Register)CX.outputData(DB, CLK.getSignal());
					DB = (Register)DX.outputData(DB, CLK.getSignal());

					//If Register is set for Input, set the data
					AX.inputData(DB, CLK.getSignal());
					BX.inputData(DB, CLK.getSignal());
					CX.inputData(DB, CLK.getSignal());
					DX.inputData(DB, CLK.getSignal());
					
					alu.Calculate(AX,BX,subtractFlag, CLK.getSignal());
					alu.shiftData(AX, CLK.getSignal());
					
					Console.Clear();			
					databus  = new LedArray(DB.getByte(), ConsoleColor.Yellow, ConsoleColor.Black);
					alubus   = new LedArray(alu.getByte(),ConsoleColor.Red, ConsoleColor.Black);
					axString = new LedArray(AX.getByte(), ConsoleColor.Green, ConsoleColor.Black);
					bxString = new LedArray(BX.getByte(), ConsoleColor.Green, ConsoleColor.Black);
					cxString = new LedArray(CX.getByte(), ConsoleColor.Green, ConsoleColor.Black);
					dxString = new LedArray(DX.getByte(), ConsoleColor.Green, ConsoleColor.Black);


					Console.Write("clock:{0}  |  clksignal:{1}  ",tick.ToString("00000000"),CLK.getSignal());
					Console.Write("\n BUS: ");
					databus.display();
					Console.Write("\n ALU: ");
					alubus.display();
					Console.Write("\n  AX: ");
					axString.display();
					Console.Write("\n  BX: ");
					bxString.display();
					Console.Write("\n  CX: ");
					cxString.display();
					Console.Write("\n  DX: ");
					dxString.display();
					Console.Write("\n");
					Thread.Sleep(200);
				}else{
					DB.reset();
				}
			}
		}
	}
}
