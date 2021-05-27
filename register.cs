using System;
using Computer;
using Latches;

namespace Latches 
{
	class Register: LatchArray {	
		public Register(){
			ComputerSystem CS = new ComputerSystem();
			Initialize((int)CS.wordsize);
		}	
	}
}
