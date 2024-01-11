using Xunit;

namespace LeetCodeChallenges.Easy;

public class Sort_Array_By_Parity
{
    public int[] SortArrayByParity(int[] nums)
    {
        int left = 0; int right = nums.Length - 1;

        while (left < right)
        {
            int leftNumber = nums[left];
            int rightNumber = nums[right];
            if (IsOdd(leftNumber))
            {
                if (IsEven(rightNumber))
                {
                    int temp = leftNumber;
                    nums[left] = rightNumber;
                    nums[right] = temp;
                }
                right--;
            }
            else
            {
                left++;
            }
        }

        return nums;
    }

    private bool IsOdd(int num) => num % 2 == 1;
    private bool IsEven(int num) => !IsOdd(num);

    [Theory]
    [InlineData(new int[] { 3, 1, 2, 4 }, new int[] { 4, 2, 1, 3 })]
    [InlineData(new int[] { 2, 2, 1, 4 }, new int[] { 2, 2, 4, 1 })]
    [InlineData(new int[] { 0 }, new int[] { 0 })]
    [InlineData(new int[] { 5, 2, 31, 56, 23, 21, 21 }, new int[] { 56, 2, 31, 5, 23, 21, 21 })]
    public void SortArrayByParityTests(int[] nums, int[] expected)
    {
        // Arrange
        // Act
        var result = SortArrayByParity(nums);

        // Assert
        Assert.Equal(expected.Length, result.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }
}
