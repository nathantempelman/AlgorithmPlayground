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
			foreach(BinaryTreeNode n in this.GetInOrder())
				Console.Write(n.Val + " ");
			Console.WriteLine();
		}

		public LinkedList<BinaryTreeNode> GetInOrder()
		{
			LinkedList<BinaryTreeNode> results = new LinkedList<BinaryTreeNode>();
			GetInOrder(results);
			return results;
		}
		private void GetInOrder(LinkedList<BinaryTreeNode> results)
		{
			if(this.Left != null)
				this.Left.GetInOrder(results);
			results.AddLast(this);
			if(this.Right != null)
				this.Right.GetInOrder(results);
		}

		/// <remarks>
		/// This may be one of the cooler things I've ever written. Only works on balanced trees though.
		/// </remarks>
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
				Console.Write(new String(' ', (int)Math.Pow(2, maxDepth - depth+1) - 1));
				while (q1.Count != 0)
				{
					var TreeNode = q1.Dequeue();
					if (TreeNode == null)
					{
						Console.Write(new String(' ', (int)Math.Pow(2, maxDepth - depth + 2)));
						continue;
					}
					Console.Write(TreeNode.Val + new String(' ', (int)Math.Pow(2, maxDepth - depth + 2)-TreeNode.Val.ToString().Length));
					q2.Enqueue(TreeNode.Left);
					q2.Enqueue(TreeNode.Right);
				}
				depth++;
				Console.WriteLine();
			}
		}

		public bool Balanced()
		{
			return this.DepthFromHere() - this.MinDepthFromHere() <= 1;
		}

		public int DepthFromHere(int currentdepth = 0)
		{
			currentdepth++;
			int leftDepth = this.Left != null ? this.Left.DepthFromHere(currentdepth) : currentdepth;
			int rightDepth = this.Right != null ? this.Right.DepthFromHere(currentdepth) : currentdepth;
			return Math.Max(leftDepth, rightDepth);
		}

		public int MinDepthFromHere(int currentdepth = 0)
		{
			currentdepth++;
			if (this.Left == null && this.Right == null)
				return currentdepth;
			int minLeft = int.MaxValue;
			int minRight = int.MaxValue;
			if (this.Left != null)
				minLeft = this.Left.MinDepthFromHere(currentdepth);
			if (this.Right != null)
				minRight = this.Right.MinDepthFromHere(currentdepth);
			return Math.Min(minRight, minLeft);
		}

		/// <summary>
		/// Returns whether or not this is a binary search tree
		/// </summary>
		/// <returns></returns>
		public bool IsBinarySearchTree()
		{
			int current = int.MinValue;
			foreach(BinaryTreeNode n in GetInOrder())
			{
				if (current > n.Val)
					return false;
				current = n.Val;
			}
			return true;
		}
	}
}
