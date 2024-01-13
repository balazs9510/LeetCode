using Xunit;

namespace LeetCodeChallenges.Easy;

public class Two_Sum
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> lookUp = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int current = nums[i];
            int diff = target - current;
            if (lookUp.ContainsKey(diff))
            {
                return new int[] { lookUp[diff], i };
            }
            else if (!lookUp.ContainsKey(current))
            {
                lookUp.Add(current, i);
            }
        }
        return null;
    }


    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new int[] { 5, 11 })]
    public void TwoSumTests(int[] num, int target, int[] expected)
    {
        // Arrange
        // Act
        var result = TwoSum(num, target);

        // Assert
        Assert.Equal(expected.Length, result.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }
}
