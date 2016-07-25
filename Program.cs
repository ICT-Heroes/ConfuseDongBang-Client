using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClientTest {
	class Program {
		static void Main(string[] args) {
			MyNet.Start();


			Thread.Sleep(10);
			while (_MyNet.isServerRun) {
				string str = Console.ReadLine();
				MyNet.Send(str);
			}

		}
	}
}
