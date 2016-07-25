using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest {
	/// <summary>
	/// 내가 그냥 만들어본 큐.
	/// </summary>
	/// <typeparam name="Tem"></typeparam>
	public class LocalQueue<Tem> {

		public LinkedList<Tem> tem = new LinkedList<Tem>();
		public bool IsEmpty() {
			return tem.Count <= 0;
		}

		public Tem Pop() {
			Tem ret = tem.First();
			tem.RemoveFirst();
			return ret;
		}

		public void Push(Tem t) {
			tem.AddLast(t);
		}
	}
}
