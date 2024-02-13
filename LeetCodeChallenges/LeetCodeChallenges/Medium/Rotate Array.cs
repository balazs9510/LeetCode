using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Medium;

public class Rotate_Array
{
    public void Rotate(int[] nums, int k)
    {
        int[] doubled = new int[nums.Length * 2];
        Array.Copy(nums, doubled, nums.Length);
        Array.Copy(nums, 0, doubled, nums.Length, nums.Length);

        Array.Copy(doubled.Skip(nums.Length - (k % nums.Length)).ToArray(), nums, nums.Length);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
    [InlineData(new int[] { -1, -100, 3, 99 }, 2, new int[] { 3, 99, -1, -100 })]
    [InlineData(new int[] { 1, 2 }, 3, new int[] { 2, 1 })]
    public void RotateTest(int[] nums, int k, int[] expected)
    {
        Rotate(nums, k);
        AssertUtils.AssertTwoArraysIsEqual(expected, nums);
    }
}
