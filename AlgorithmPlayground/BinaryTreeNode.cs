using System;
using System.Collections.Generic;

namespace AlgorithmPlayground
{
	public class BinaryTreeNode
	{
		public int Val;
		public BinaryTreeNode Left;
		public BinaryTreeNode Right;
		public BinaryTreeNode(int x) { Val = x; }
		public BinaryTreeNode(int[] arr)
		{
			// unfortunately can't assign to this, so
			var tmp = ConvertArrayToTree(arr);
			this.Left = tmp.Left;
			this.Right = tmp.Right;
			this.Val = tmp.Val;
		}
		private BinaryTreeNode ConvertArrayToTree(int[] turnintotree)
		{
			return ConvertArrayToTree(turnintotree, 0, turnintotree.Length - 1);
		}
		private BinaryTreeNode ConvertArrayToTree(int[] arr, int start, int end)
		{
			if (start > end)
				return null;
			if (start == end)
				return new BinaryTreeNode(arr[start]);
			int headpos = start + (end - start) / 2;
			BinaryTreeNode head = new BinaryTreeNode(arr[headpos]);
			head.Left = ConvertArrayToTree(arr, start, headpos - 1);
			head.Right = ConvertArrayToTree(arr, headpos + 1, end);
			return head;
		}
		public void InOrderPrint()
		{
			InOrderPrint(this);
			Console.WriteLine();
		}
		private void InOrderPrint(BinaryTreeNode n)
		{
			if (n == null)
				return;
			InOrderPrint(n.Left);
			Console.Write(n.Val + " ");
			InOrderPrint(n.Right);
		}

		// This may be one of the cooler things I've ever written. 
		public void PrettyPrintTree()
		{
			// bfs through, print based on depth, seperate each depth into different queue
			Queue<BinaryTreeNode> q1 = new Queue<BinaryTreeNode>();
			Queue<BinaryTreeNode> q2 = new Queue<BinaryTreeNode>();
			int depth = 1;
			int maxDepth = this.DepthFromHere();
			int treedepth = DepthFromHere();
			q2.Enqueue(this);

			while ((q1 = q2).Count != 0)
			{
				if (depth > maxDepth)
					break;
				q2 = new Queue<BinaryTreeNode>();
				Console.Write(new String('\t', (int)Math.Pow(2, maxDepth - depth) - 1));
				while (q1.Count != 0)
				{
					var TreeNode = q1.Dequeue();
					if (TreeNode == null)
					{
						Console.Write(new String('\t', (int)Math.Pow(2, maxDepth - depth + 1)));
						continue;
					}
					Console.Write(TreeNode.Val + new String('\t', (int)Math.Pow(2, maxDepth - depth + 1)));
					q2.Enqueue(TreeNode.Left);
					q2.Enqueue(TreeNode.Right);
				}
				depth++;
				Console.WriteLine();
			}
		}

		public int DepthFromHere(int currentdepth = 0)
		{
			currentdepth++;
			int leftDepth = this.Left != null ? this.Left.DepthFromHere(currentdepth) : currentdepth;
			int rightDepth = this.Right != null ? this.Right.DepthFromHere(currentdepth) : currentdepth;
			return Math.Max(leftDepth, rightDepth);
		}
	}
}
