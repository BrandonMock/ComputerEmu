using System;
using System.Collections.Generic;
using Displays;

namespace Displays 
{
	class LedArray
	{
		List<Led> data = new List<Led>();
		
		public LedArray(string val, ConsoleColor on, ConsoleColor off)
		{
			Initialize(val.Length, on, off);
			load(val);
		}
		public LedArray(int size)
		{
			Initialize(size, ConsoleColor.Green, ConsoleColor.Red);	
		}	
		public LedArray(int size, ConsoleColor on, ConsoleColor off)
		{
			Initialize(size, on, off);
		}
		public LedArray(int size, ConsoleColor on)
		{
			Initialize(size, on, ConsoleColor.Gray);
		}

		public void Initialize(int size, ConsoleColor on, ConsoleColor off)
		{
			data.Clear();
			for(int i = 0; i<size; ++i){
				var tmpLed = new Led();
				tmpLed.off();
				tmpLed.SetOnColor(on);
				tmpLed.SetOffColor(off);
				data.Add(tmpLed);
			}
		}
		
		public void display(){
			foreach(var a in data){
				a.display();
			}
		}

		public void load(string val)
		{
			int i=0;
			foreach(char a in val.ToCharArray())
			{
				if (a=='1'){
					data[i].on();
				}else{
					data[i].off();
				}
				i++;
			}
		}			

	}
}
