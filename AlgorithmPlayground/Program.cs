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

			int[] turnintotree = ArrayLib.CreateArray(10);

			BinaryTreeNode treeHead = new BinaryTreeNode(turnintotree);
			treeHead.InOrderPrint();
			treeHead.PrettyPrintTree();


			Console.Read();
		}


	}
}
