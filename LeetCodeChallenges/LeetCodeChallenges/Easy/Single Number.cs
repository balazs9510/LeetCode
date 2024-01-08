using Xunit;

namespace LeetCodeChallenges.Easy;
public class Single_Number_
{
    public int SingleNumber(int[] nums)
    {
        var found = new HashSet<int>(); 
        for (int i = 0; i < nums.Length; i++)
        {
            if (found.Contains(nums[i]))
            {
                found.Remove(nums[i]);
            }
            else
            {
                found.Add(nums[i]);
            }
        }
        return found.First();
    }


    [Theory]
    [InlineData(new int[] { 2, 2, 1 }, 1)]
    [InlineData(new int[] { 4, 1, 2, 1, 2 }, 4)]
    [InlineData(new int[] { 1 }, 1)]
    public void SingleNumberTests(int[] numbers, int expected)
    {
        // Arrange
        // Act
        var result = SingleNumber(numbers);

        // Assert
        Assert.Equal(expected, result);
    }
}
