using System;
using Logic;

namespace Latches
{
	class Latch
	{
		AND  a1 = new AND();
		AND  a2 = new AND();
		NAND n1 = new NAND();
		NAND n2 = new NAND();
		NAND n3 = new NAND();
		NAND n4 = new NAND();

		public Latch(){
			Reset();
		}

		public void Reset(){
			n1.setI(1,false);
			n1.setI(2,false);
			n2.setI(1,false);
			n2.setI(2,false);
			n3.setI(1,false);
			n3.setI(2,false);
			n4.setI(1,false);
			n4.setI(2,false);
			a1.setI(1,false);
			a1.setI(2,false);
			a2.setI(1,false);
			a2.setI(2,false);
			Set(false,true,true);
		}
		
		public void Set(bool j, bool k, bool clock){
			
			a1.setI(1,n3.getO());
			a1.setI(2,j);
			a2.setI(1,n4.getO());
			a2.setI(2,k);
			n1.setI(1,a1.getO());
			n1.setI(2,clock);
			n2.setI(1,a2.getO());
			n2.setI(2,clock);
			n3.setI(1,n4.getO());
			n3.setI(2,n2.getO());
			n4.setI(1,n3.getO());
			n4.setI(2,n1.getO());
		}
	
		public bool getValue(){
			return(n4.getO());
		}
	}
}
