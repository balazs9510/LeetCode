using Xunit;

namespace LeetCodeChallenges.Medium;

public class Maximum_Subarray
{
    public int MaxSubArray(int[] nums)
    {
        var currentSum = nums[0];
        var max = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            if (currentSum < 0) currentSum = 0;
            currentSum += nums[i];
            max = Math.Max(currentSum, max);
        }

        return max;    
    }


    [Theory]
    [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 5, 4, -1, 7, 8 }, 23)]
    [InlineData(new int[] { -2, 1, -3, -4, 1, 2, 1, -5, 4 }, 4)]
    public void MaxSubArrayTests(int[] nums, int expected) => Assert.Equal(expected, MaxSubArray(nums));
}
