using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPlayground
{
	public class ListNode
	{
		public int val;
		public ListNode next;
		public ListNode(int x) { val = x; }
		public void Print()
		{
			ListNode current = this;
			do
			{
				Console.Write(current.val + " ->");
				current = current.next;
			}
			while (current.next != null);
			Console.WriteLine(current.val);
			Console.WriteLine(" Head:" + this.val + ".");
		}

		public int Count()
		{
			int count = 0;
			ListNode start = this;
			ListNode current = start;
			while (true)
			{
				if (current != null)
				{
					current = current.next;
					count++;
				}
				else
					break;
			}
			return count;
		}
	}
}
