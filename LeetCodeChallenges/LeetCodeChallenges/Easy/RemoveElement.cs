using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Easy
{
	public partial class EasySolution
	{
		public int RemoveElement(int[] nums, int val)
		{
			int shift = 0;
			for (int i = 0; i < nums.Length; i++)
			{
				int currentItem = nums[i];
				if (currentItem == val)
				{
					shift++;
				} else if (shift > 0)
				{
					nums[i - shift] = currentItem;
				}
			}
			return nums.Length - shift;
		}

		public static void RemoveElementTests()
		{
			//Instance.RemoveElement(new int[] { 3, 2, 2, 3 }, 3);
			//Instance.RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2);
			//Instance.RemoveElement(new int[] { 1, 1, 2 }, 1);
			//Instance.RemoveElement(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 4);
		}
	}
}
