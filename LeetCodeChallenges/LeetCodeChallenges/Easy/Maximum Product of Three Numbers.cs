using Xunit;

namespace LeetCodeChallenges.Easy;

public class Maximum_Product_of_Three_Numbers
{
    public int MaximumProduct(int[] nums)
    {
        Array.Sort(nums);

        int n = nums.Length - 1;
        return Math.Max(nums[0] * nums[1] * nums[n], nums[n - 2] * nums[n - 1] * nums[n]);
    }


    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 6)]
    [InlineData(new int[] { 1, 2, 3, 4 }, 24)]
    [InlineData(new int[] { -1, -2, -3 }, -6)]
    [InlineData(new int[] { -1, -2, -3, 50 }, 300)]
    [InlineData(new int[] { -1, -2, -3, 1 }, 6)]
    public void MaximumProductTests(int[] nums, int expected)
    {
        // Arrange
        // Act
        // Assert
        Assert.Equal(expected, MaximumProduct(nums));
    }
}
