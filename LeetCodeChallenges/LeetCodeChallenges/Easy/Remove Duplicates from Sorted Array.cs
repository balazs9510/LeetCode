using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class RemoveDuplicates_
{
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        int count = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            int currentItem = nums[i];
            if (currentItem > nums[count])
            {
                nums[++count] = currentItem;
            }
        }
        return count + 1;
    }


    [Theory]
    [InlineData(new int[] { 1, 1, 2 }, 2)]
    [InlineData(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5)]
    public void RemoveDuplicatesTests(int[] nums, int expected)
    {
        // Arrange


        // Act
        var result = RemoveDuplicates(nums);

        // Assert
        Assert.Equal(expected, result);
        for (int i = 0; i < result - 1; i++)
        {
            Assert.True(nums[i] < nums[i + 1]);
        }
    }
}
