using Xunit;

namespace LeetCodeChallenges.Easy;

public class Move_Zeroes
{
    // Two-pointer solution
    // O(n) time, O(1) aux. space
    public void MoveZeroes(int[] nums)
    {
        int left = 0; int right = 0;
        int n = nums.Length;
        Func<bool> lessThanSize = () => left < n && right < n;
        while (lessThanSize())
        {
            if (nums[left] != 0) left++;
            if (nums[right] == 0) right++; 

            if (lessThanSize() && left < right)
            {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
            }

            right++;
        }
    }

    // Double array solutin
    // O(n) time, O(n) aux. space
    public void MoveZeroesTwoCopies(int[] nums)
    {
        // try one
        int[] newNums = new int[nums.Length];
        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                newNums[index++] = nums[i];
            }
        }
        Array.Copy(newNums, nums, nums.Length);
    }


    [Theory]
    [InlineData(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
    [InlineData(new int[] { 1, 3, 12, 0, 0, 0, 0 }, new int[] { 1, 3, 12, 0, 0, 0, 0 })]
    [InlineData(new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 })]
    [InlineData(new int[] { 4, 56, 6 }, new int[] { 4, 56, 6 })]
    [InlineData(new int[] { 0 }, new int[] { 0 })]
    public void MoveZeroesTests(int[] nums, int[] expected)
    {
        // Arrange
        // Act
        MoveZeroes(nums);

        // Assert
        for (int i = 0; i < nums.Length; i++)
        {
            Assert.Equal(expected[i], nums[i]);
        }
    }
}
