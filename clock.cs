using System;
using System.Threading;
using Computer;

namespace Computer
{
	class Clock
	{
		double tick;
		bool signal;
		bool halt;
		bool manual;

		public Clock(){
			tick=0;
			signal=false;
			manual=false;
		}
		
		public double getNextClock(){
			if(manual){
			    Console.Read();
			}
			
			if(!halt){
				tick=tick+.5;
				if (!manual) {
					//Thread.Sleep();
				}
				return(tick);
			}else{
				return 0;
			}
		}

		public bool getSignal(){
			if(!halt){
				if ( (int)(tick) == (double)tick ){
					signal = true;
				} else {
					signal = false;
				}
			} else {
				signal = false;
			}	
			return signal;
		}

		public void setHalt(bool val){
			halt=val;
		}

		public void setManual(bool value){
			manual = value;
		}
	}
}
