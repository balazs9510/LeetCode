using Xunit;

namespace LeetCodeChallenges.Easy;

public class Find_All_Numbers_Disappeared_in_an_Array
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        //var set = new HashSet<int>();
        //var result = new List<int>();
        //for (int i = 0; i < nums.Length; i++)
        //{
        //    set.Add(nums[i]);
        //}

        //for (int i = 1; i <= nums.Length; i++)
        //{
        //    if (set.Contains(i)) continue;
        //    result.Add(i);
        //}

        //return result;

        for (int i = 0; i < nums.Length; i++)
        {
            // lets say we have a list in order from 1 to N. Then the index of each i in the array would be: 
            int index = Math.Abs(nums[i]) - 1; 
            // negate the number
            if (nums[index] > 0) nums[index] = -nums[index];
        }
        List<int> result = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            // when the position is not negated, then there was a duplicated element on that position. Add 1 because its from 1 to N
            if (nums[i] > 0) result.Add(i + 1);
        }
        return result;
    }


    [Theory]
    [InlineData(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new int[] { 5, 6 })]
    [InlineData(new int[] { 1, 1 }, new int[] { 2 })]
    public void FindDisappearedNumbersTests(int[] nums, int[] expected)
    {
        // Arrange
        // Act
        var result = FindDisappearedNumbers(nums);

        // Assert
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }
}
