using Xunit;

namespace LeetCodeChallenges.Easy;

public class Remove_One_Element_to_Make_the_Array_Strictly_Increasing
{
    public bool CanBeIncreasing(int[] nums)
    {
        if (nums.Length == 2) return true;

        for (int i = 0; i < nums.Length; i++)
        {
            var prev = nums.Take(i).ToArray();
            var next = nums.Skip(i + 1).Take(nums.Length - i - 1).ToArray();
            if (IsStrictlyAscending(prev) && IsStrictlyAscending(next))
            {
                if (prev.Length == 0) return true;
                if (next.Length == 0) return true;
                if (prev[prev.Length - 1] < next[0]) return true;
            }
        }

        return false;
    }

    public bool CanBeIncreasingOptimal(int[] nums)
    {
        int wrongPosition = 0, prev = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= prev)
            {
                wrongPosition++;
                if (wrongPosition > 1) return false;
                // determine to remove the current number or the one before
                prev = i > 1 && nums[i] <= nums[i - 2] ? nums[i - 1] : nums[i];

            }
            else prev = nums[i];
        }

        return true;
    }

    private bool IsStrictlyAscending(int[] input)
    {
        for (int i = 1; i < input.Length; i++)
        {
            if (input[i - 1] >= input[i]) return false;
        }

        return true;
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 10, 5, 7 }, true)]
    [InlineData(new int[] { 1, 2, 10, 11, 5, 7 }, false)]
    [InlineData(new int[] { 1, 2, 10, 4, 11, 5, 7 }, false)]
    [InlineData(new int[] { 2, 3, 1, 2 }, false)]
    [InlineData(new int[] { 1, 1, 1 }, false)]
    [InlineData(new int[] { 1, 1 }, true)]
    [InlineData(new int[] { 100, 21, 100 }, true)]
    public void CanBeIncreasingTests(int[] input, bool expected)
    {
        // Arrange
        // Act
        var result = CanBeIncreasingOptimal(input);

        // Assert
        Assert.Equal(expected, result);
    }
}
