using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest {
	public class NetString {
		public int id;
		public string[] param;

		public string GetString() {
			string ret = id + "";
			if (param != null) {
				for (int i = 0; i < param.Length; i++) {
					ret += "," + param[i];
				}
			}
			return ret + ";";
		}

		public static NetString Get(string str) {
			char[] sp = new char[2];
			sp[0] = ','; sp[1] = ';';
			string[] strs = str.Split(sp);
			return new NetString(int.Parse(strs[0]), strs);
		}

		public NetString(int id) {
			this.id = id;
			this.param = null;
		}
		public NetString(int id, string[] strs) {
			this.id = id;
			this.param = new string[strs.Length - 1];
			for (int i = 1; i < param.Length; i++)
				this.param[i - 1] = strs[i];
		}

		public NetString() {
			this.id = MyNet.myId;
			this.param = null;
		}
		public NetString(string[] strs) {
			this.id = MyNet.myId;
			this.param = new string[strs.Length];
			for (int i = 0; i < param.Length; i++)
				this.param[i] = strs[i];
		}
		public NetString(string param0) {
			this.id = MyNet.myId;
			this.param = new string[1];
			this.param[0] = param0;
		}
		public NetString(string param0, string param1) {
			this.id = MyNet.myId;
			this.param = new string[2];
			this.param[0] = param0;
			this.param[1] = param1;
		}
		public NetString(string param0, string param1, string param2) {
			this.id = MyNet.myId;
			this.param = new string[3];
			this.param[0] = param0;
			this.param[1] = param1;
			this.param[2] = param2;
		}
		public NetString(string param0, string param1, string param2, string param3) {
			this.id = MyNet.myId;
			this.param = new string[4];
			this.param[0] = param0;
			this.param[1] = param1;
			this.param[2] = param2;
			this.param[3] = param3;
		}
		public NetString(string param0, string param1, string param2, string param3, string param4) {
			this.id = MyNet.myId;
			this.param = new string[5];
			this.param[0] = param0;
			this.param[1] = param1;
			this.param[2] = param2;
			this.param[3] = param3;
			this.param[4] = param4;
		}
		public NetString(string param0, string param1, string param2, string param3, string param4, string param5) {
			this.id = MyNet.myId;
			this.param = new string[6];
			this.param[0] = param0;
			this.param[1] = param1;
			this.param[2] = param2;
			this.param[3] = param3;
			this.param[4] = param4;
			this.param[5] = param5;
		}
		public NetString(string param0, string param1, string param2, string param3, string param4, string param5, string param6) {
			this.id = MyNet.myId;
			this.param = new string[7];
			this.param[0] = param0;
			this.param[1] = param1;
			this.param[2] = param2;
			this.param[3] = param3;
			this.param[4] = param4;
			this.param[5] = param5;
			this.param[6] = param6;
		}
		public NetString(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7) {
			this.id = MyNet.myId;
			this.param = new string[8];
			this.param[0] = param0;
			this.param[1] = param1;
			this.param[2] = param2;
			this.param[3] = param3;
			this.param[4] = param4;
			this.param[5] = param5;
			this.param[6] = param6;
			this.param[7] = param7;
		}
		public NetString(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8) {
			this.id = MyNet.myId;
			this.param = new string[9];
			this.param[0] = param0;
			this.param[1] = param1;
			this.param[2] = param2;
			this.param[3] = param3;
			this.param[4] = param4;
			this.param[5] = param5;
			this.param[6] = param6;
			this.param[7] = param7;
			this.param[8] = param8;
		}
		public NetString(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9) {
			this.id = MyNet.myId;
			this.param = new string[10];
			this.param[0] = param0;
			this.param[1] = param1;
			this.param[2] = param2;
			this.param[3] = param3;
			this.param[4] = param4;
			this.param[5] = param5;
			this.param[6] = param6;
			this.param[7] = param7;
			this.param[8] = param8;
			this.param[9] = param9;
		}
		public NetString(string param0, string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10) {
			this.id = MyNet.myId;
			this.param = new string[11];
			this.param[0] = param0;
			this.param[1] = param1;
			this.param[2] = param2;
			this.param[3] = param3;
			this.param[4] = param4;
			this.param[5] = param5;
			this.param[6] = param6;
			this.param[7] = param7;
			this.param[8] = param8;
			this.param[9] = param9;
			this.param[10] = param10;
		}
	}
	}
