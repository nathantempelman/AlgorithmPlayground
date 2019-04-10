using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmPlayground;

namespace UnitTests
{
	[TestClass]
	public class BinaryTreeTests
	{
		[TestMethod]
		public void TestPrettyPrint()
		{
		}

		[TestMethod]
		public void TestBalanced()
		{
			// Any tree created like this should be balanced
			int[] turnintotree = ArrayLib.CreateArray(10);
			BinaryTreeNode treeHead = new BinaryTreeNode(turnintotree);
		
			Assert.IsTrue(treeHead.Balanced());

			// add another node to unbalance the tree
			BinaryTreeNode tmp = treeHead;
			while (tmp.Right != null)
				tmp = tmp.Right;
			tmp.Right = new BinaryTreeNode(42);

			Assert.IsFalse(treeHead.Balanced());
		}

		[TestMethod]
		public void TestIsBST()
		{
			// Any tree created like this should be a BST
			int[] turnintotree = ArrayLib.CreateArray(10);
			BinaryTreeNode treeHead = new BinaryTreeNode(turnintotree);

			Assert.IsTrue(treeHead.IsBinarySearchTree());

			// add another node to mess it up
			BinaryTreeNode tmp = treeHead;
			while (tmp.Right != null)
				tmp = tmp.Right;
			tmp.Right = new BinaryTreeNode(-42);

			Assert.IsFalse(treeHead.Balanced());
		}
	}
}
