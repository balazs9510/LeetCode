using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Easy
{
	public partial class EasySolution
	{
		public int RemoveDuplicates(int[] nums)
		{
			int count = 0, current = -101;
			for (int i = 0; i < nums.Length; i++)
			{
				int currentItem = nums[i];
				if (currentItem > current)
				{
					current = currentItem;
					nums[count++] = currentItem;
				}
			}
			return count;
		}

		public static void RemoveDuplicatesTests()
		{
			//Instance.RemoveDuplicates(new int[] { 1, 1, 2 });
			//Instance.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 });
		}
	}
}
