using System;

namespace Displays 
{
	class Led
	{
		bool val;
		ConsoleColor onColor;
		ConsoleColor offColor;


		public Led(){
		}	

		public void on(){
			val = true;
		}
		public void off(){
			val = false;
		}
		
		public void SetOnColor(ConsoleColor color)
		{
			onColor = color;
		}

		
		public void SetOffColor(ConsoleColor color)
		{
			offColor = color;
		}

		public void display(){
			var backupFG = Console.ForegroundColor;
			var backupBG = Console.BackgroundColor;			
			
			//Console.BackgroundColor = ConsoleColor.Black;
			if (val) {
				Console.ForegroundColor = onColor;	
			} else {
				Console.ForegroundColor = offColor;
			}
			Console.Write("\u25cf");
			Console.ForegroundColor = backupFG;
			Console.BackgroundColor = backupBG;
		}


	}
}
