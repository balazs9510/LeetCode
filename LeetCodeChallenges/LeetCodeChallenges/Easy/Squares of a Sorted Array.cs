using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Squares_of_a_Sorted_Array
{
    // Two pointer O(n)
    public int[] SortedSquares(int[] nums)
    {
        int left = 0; int right = nums.Length - 1;
        int length = nums.Length - 1;
        int[] result = new int[nums.Length];
        int insertCount = 0;
        while (left <= right)
        {
            var sLeft = nums[left] * nums[left];
            var sRight = nums[right] * nums[right];

            if (sLeft >= sRight)
            {
                result[length - insertCount] = sLeft; insertCount++;
                left++;
            } else
            {
                result[length - insertCount] = sRight; insertCount++;
                right--;
            }
        }

        return result;
    }

    // Merge sort solution O(n logn)
    public int[] SortedSquares2(int[] nums)
    {
        return DivideAndMerge(nums, 0, nums.Length - 1);
    }

    private int[] DivideAndMerge(int[] nums, int left, int right)
    {
        if (left >= right) return new int[] { nums[left] * nums[left] };

        var subArrays = Divide(nums, left, right);

        return Merge(subArrays.Item1, subArrays.Item2);
    }

    private (int[], int[]) Divide(int[] nums, int left, int right)
    {
        var middle = left + (right - left) / 2;
        var a = DivideAndMerge(nums, left, middle);
        var b = DivideAndMerge(nums, middle + 1, right);

        return (a, b);
    }

    private int[] Merge(int[] a, int[] b)
    {
        int i = 0; int j = 0;
        var result = new int[a.Length + b.Length];
        while (i < a.Length || j < b.Length)
        {
            if (i == a.Length)
                result[i + j] = b[j++];
            else if (j == b.Length)
                result[i + j] = a[i++];
            else if (a[i] < b[j])
                result[i + j] = a[i++];
            else
                result[i + j] = b[j++];
        }

        return result;
    }

    [Theory]
    [InlineData(new int[] { -4, -1, 0, 3, 10 }, new int[] { 0, 1, 9, 16, 100 })]
    [InlineData(new int[] { -7, -3, 2, 3, 11 }, new int[] { 4, 9, 9, 49, 121 })]
    public void SortedSquaresTests(int[] nums, int[] expected)
    {
        AssertUtils.AssertTwoArraysIsEqual(expected, SortedSquares(nums));
    }
}
