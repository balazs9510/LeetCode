using Xunit;

namespace LeetCodeChallenges.Easy;

public class Find_Pivot_Index
{
    public int PivotIndex(int[] nums)
    {
        long allSum = nums.Select(x => (long)x).Sum();
        long leftSum = 0;
        //if (leftSum == (allSum - nums[0])) return 0;
        //if (leftSum == (allSum - nums[nums.Length - 1])) return nums.Length - 1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0)
                leftSum += nums[i - 1];
            if (leftSum * 2 == (allSum - nums[i])) return i;
        }

        return -1;
    }

    [Theory]
    [InlineData(new int[] { 1, 7, 3, 6, 5, 6 }, 3)]
    [InlineData(new int[] { 1, 2, 3 }, -1)]
    [InlineData(new int[] { -1, -1, 0, 1, 1, 0 }, 5)]
    [InlineData(new int[] { 2, 1, -1 }, 0)]
    [InlineData(new int[] { int.MinValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MinValue }, 2)]
    public void PivotIndexTests(int[] nums, int expected)
    {
        // Arrange
        // Act
        // Assert
        Assert.Equal(expected, PivotIndex(nums));
    }
}
