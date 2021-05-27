using System;
using Latches;

namespace Displays
{
	class SevenSegment
	{	
		bool A;
		bool B;
		bool C;
		bool D;
		bool E;
		bool F;
		bool G;
		bool DP;

		public SevenSegment()
		{
		}

		public SevenSegment(bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool dp){
			A=a;
			B=b;
			C=c;
			D=d;
			E=e;
			F=f;
			G=g;
			DP=dp;

		}

		public void Display(){
			if (A) { Console.Write(" _ \n"); } else { Console.Write("   \n");  }
			if (F) { Console.Write("|");     } else { Console.Write(" ");      }
			if (G) { Console.Write("_");     } else { Console.Write(" ");      }
			if (B) { Console.Write("| \n");  } else { Console.Write("  \n");   }
			if (E) { Console.Write("|");     } else { Console.Write(" ");      }
			if (D) { Console.Write("_");     } else { Console.Write(" ");      }
			if (C) { Console.Write("|");     } else { Console.Write(" ");      }
			if (DP){ Console.Write(".\n");   } else { Console.Write(" \n");    } 
		}
	}
};
