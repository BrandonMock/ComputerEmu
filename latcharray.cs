using System;
using Computer;
using Latches;
using System.Collections.Generic;

namespace Latches
{

	class LatchArray
	{
		ComputerSystem CS = new ComputerSystem();
		bool enable;
		bool IO;
		List<Latch> data = new List<Latch>();
	
		public LatchArray(){
			Initialize((int)CS.wordsize);
			reset();
		}

		public List<Latch> GetList(){
			return data;
		}

		public LatchArray(int bits){
			Initialize(bits);
			reset();
		}
		
		public void Initialize(int bits){
			this.resize(bits);
		}
	
		public void resize(int bits){
			Console.WriteLine(bits);
			data.Clear();
			for (int i = 0; i<bits; ++i){
				var temp = new Latch();
				data.Add(temp);
			}
		}


		public void reset(){
			for (int i=0; i<data.Count; ++i){
				data[i].Reset();
			}
		}
	
		public void setBit(int bit, bool val, bool clock){
			data[bit].Set(val,enable,clock);
		}
	
		public bool getBit(int bit){
			return(data[bit].getValue());
		}
	
		public string getByte(){
			string temp = new string('0',(int)CS.wordsize);
			string output = "";
			int i=(int)CS.wordsize;
			var charArray = temp.ToCharArray();
			foreach(var a in charArray){
				--i;
				if(data[i].getValue()){
					output=output+"1";
				}else{
					output=output+"0";			
				}
			}
			return output;
		}

		public LatchArray outputData(LatchArray DB, bool clock){
			if(enable && !IO){
				int i = 0;
				foreach(var a in DB.GetList()){
					DB.setBit(i,data[i].getValue(),clock);
					++i;
				}
			}
			return(DB);
		}

		public void inputData(LatchArray DB, bool clock){
			if(enable && IO){
				for(int i=0; i<data.Count; ++i){
					data[i].Set(DB.getBit(i),enable,clock);
				}
			}
		}

		public void setValue(string value){
			Console.WriteLine(value);
			var charArray = value.ToCharArray();
			int i=0;			
			foreach (char a in charArray){
				Console.Write(i);
				Console.Write(" - ");
				Console.Write(data.Count-1);
				Console.Write(" - ");
				Console.Write((data.Count-1)-i);
				Console.Write("\n");
				if(a==48){
					data[(data.Count-1)-i].Set(false,true,true);
				}else{
					data[(data.Count-1)-i].Set(true,true,true);
				}
				++i;
			}
		}
	
		public void setInput(){
			IO = true;
		}
		public void setOutput(){
			IO = false;	
		}
		public void setEnable(bool val){
			enable = val;
		}
	}
}
