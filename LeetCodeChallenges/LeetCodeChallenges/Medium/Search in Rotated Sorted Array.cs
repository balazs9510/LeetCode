using Xunit;

namespace LeetCodeChallenges.Medium;

public class Search_in_Rotated_Sorted_Array
{

    public int Search(int[] nums, int target) => Array.IndexOf(nums, target);

    // O log n
    public int SearchLog(int[] nums, int target)
    {
        int l = 0; int r = nums.Length - 1;
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            int middle = nums[m];
            if (middle == target) return m;

            int right = nums[r];
            // alja shiftelt
            if (middle > right)
            {
                if (middle > target && right >= target)
                {
                    l = m + 1;
                }
                if (middle > target && right < target)
                {
                    r = m - 1;
                }

                if (middle < target && right < target)
                {
                    l = m + 1;
                }
            }
            else
            {
                if (middle > target || target > right)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }

        }

        return -1;
    }
    [Theory]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0, 4)]
    [InlineData(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3, -1)]
    [InlineData(new int[] { 0, 1, 2, 4, 5, 6, 7 }, 0, 0)]
    [InlineData(new int[] { 0, 1, 2, 4, 5, 6, 7 }, 6, 5)]
    [InlineData(new int[] { 10, 11, 34, 5, 6, 7 }, 11, 1)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 0 }, 0, 5)]
    [InlineData(new int[] { 5, 1, 3 }, 5, 0)]
    [InlineData(new int[] { 1 }, 0, -1)]
    [InlineData(new int[] { 4, 5, 6, 7, 8, 1, 2, 3 }, 8, 4)]
    public void SearchTests(int[] nums, int target, int expected) => Assert.Equal(expected, Search(nums, target));
}
