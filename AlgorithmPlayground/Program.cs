using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPlayground
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] turnintotree = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

			BinaryTreeNode treeHead = new BinaryTreeNode(turnintotree);
			treeHead.InOrderPrint();
			treeHead.PrettyPrintTree();




			Console.Read();
		}
	}
}
