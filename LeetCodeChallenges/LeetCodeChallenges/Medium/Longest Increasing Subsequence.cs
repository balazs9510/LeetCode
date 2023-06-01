using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Longest_Increasing_Subsequence
    {
        public int LengthOfLIS(int[] nums)
        {
            var dp = Enumerable.Repeat(1, nums.Length).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }


            return dp.Max();
        }


        [Theory]
        [InlineData(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
        [InlineData(new int[] { 0, 1, 0, 3, 2, 3 }, 4)]
        [InlineData(new int[] { 7, 7, 7, 7, 7, 7, 7 }, 1)]
        [InlineData(new int[] { 3, 5, 6, 2, 5, 4, 19, 5, 6, 7, 12 }, 6)]
        [InlineData(new int[] { 5, 7, -24, 12, 13, 2, 3, 12, 5, 6, 35 }, 6)]
        public void LengthOfLISTests(int[] nums, int expected)
        {
            // Arrange & act
            var res = LengthOfLIS(nums);

            // Assert
            Assert.Equal(expected, res);
        }

    }
}
