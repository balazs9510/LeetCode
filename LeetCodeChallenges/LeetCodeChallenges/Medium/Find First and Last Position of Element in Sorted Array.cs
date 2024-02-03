using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Medium;

public class Find_First_and_Last_Position_of_Element_in_Sorted_Array
{
    public int[] SearchRange(int[] nums, int target)
    {
        var min = -1;
        var max = -1;
        if (nums.Length == 0) return new[] { min, max };
        var l = 0; var r = nums.Length - 1;

        while (l <= r)
        {
            var m = l + (r - l) / 2;
            if (nums[m] == target) { min = m; if (max == -1) max = min; }
            if (nums[m] >= target)
            {

                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }
        if (min == -1) return new[] { min, max };
        l = max;
        r = nums.Length - 1;
        while (l <= r)
        {
            var m = l + (r - l) / 2;
            if (nums[m] == target) max = m;
            if (nums[m] > target)
            {
                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }

        return new int[] { min, max };
    }


    [Theory]
    [InlineData(new int[] { 5, 7, 7, 8, 8, 10 }, 8, new int[] { 3, 4 })]
    [InlineData(new int[] { 5, 7, 7, 8, 8, 10 }, 6, new int[] { -1, -1 })]
    [InlineData(new int[] { }, 0, new int[] { -1, -1 })]
    [InlineData(new int[] { 1, 1, 1, 1, 1, 9, 9, 10, 10, 10, 10, 10, 50 }, 10, new int[] { 7, 11 })]
    [InlineData(new int[] { 1, 1, 1, 1 }, 1, new int[] { 0, 3 })]
    [InlineData(new int[] { 0, 1, 1, 1 }, 1, new int[] { 1, 3 })]
    [InlineData(new int[] { 1, 1, 1, 2 }, 1, new int[] { 0, 2 })]
    [InlineData(new int[] { 1 }, 1, new int[] { 0, 0 })]
    [InlineData(new int[] { 1 }, 0, new int[] { -1, -1 })]
    [InlineData(new int[] { 1, 2, 3 }, 1, new int[] { 0, 0 })]
    [InlineData(new int[] { 0, 0, 1, 2, 2 }, 0, new int[] { 0, 1 })]
    public void SearchRangeTests(int[] nums, int target, int[] expected) => AssertUtils.AssertTwoArraysIsEqual(expected, SearchRange(nums, target));
}
