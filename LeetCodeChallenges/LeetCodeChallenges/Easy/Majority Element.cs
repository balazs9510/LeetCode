using Xunit;

namespace LeetCodeChallenges.Easy;

public class Majority_Element
{
    public int MajorityElement(int[] nums)
    {
        Array.Sort(nums);

        return nums[nums.Length / 2];
    }


    [Theory]
    [InlineData(new int[] { 3, 2, 3 }, 3)]
    [InlineData(new int[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
    [InlineData(new int[] { 5,6,7,8,5,-1,-3,-32,5,5,5 }, 5)]
    public void MajorityElementTests(int[] nums, int expected)
    {
        Assert.Equal(expected, MajorityElement(nums));
    }
}
