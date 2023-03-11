using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Easy
{
	public partial class EasySolution
	{
		public int SearchInsert(int[] nums, int target)
		{
			int l = 0, r = nums.Length - 1;
			int m = r / 2;
			while (l <= r)
			{
				int c = nums[m];
				if (c == target) return m;

				if (c > target)
				{
					r = m - 1;
				}
				else
				{
					l = m + 1;
				}
				m = l + (r - l) / 2;
			}

			if (m >= nums.Length) return m;
			if (m <= 0) return 0;

			return nums[m] > target ? m : m + 1;
		}

		public static void SearchInsertTests()
		{
			//Console.WriteLine(Instance.SearchInsert(new[] { 1, 3, 5, 6 }, 4));
			//Console.WriteLine(Instance.SearchInsert(new[] { 1, 3, 5, 6 }, -1));
			//Console.WriteLine(Instance.SearchInsert(new[] { 1, 3, 5, 6 }, 5));
			//Console.WriteLine(Instance.SearchInsert(new[] { 1, 3, 5, 6 }, 2));
			//Console.WriteLine(Instance.SearchInsert(new[] { 1, 3, 5, 6 }, 7));
		}
	}
}
