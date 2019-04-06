using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmPlayground
{
	static class ArrayLib
	{
		public static int[] CreateArray(int length)
		{
			int[] res = new int[length];
			for (int i = 1; i <= length; i++)
			{
				res[i-1] = i;
			}
			return res;
		}
	}
}
