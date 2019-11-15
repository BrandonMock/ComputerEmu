using System;

namespace NAND
{
	class NAND{
		bool[] I = new bool[5];
		bool O;

		public NAND(){
			//do nothing
		}

		public void setI(int index, bool val){
			I[index]=val;
			O = false;
			for (int i=1; i<=2; i++){
				if(I[i]==false){
					O = true;	
				}
			}
		}
			
		public bool getI(int i){
			return(I[i]);
		}
		
		public bool getO(){
			return O;
		}
	}
}
