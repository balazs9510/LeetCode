using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Intersection_of_Two_Arrays_II
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        // 1 <= nums1.length, nums2.length <= 1000
        var arr = new int[1000];

        for (int i = 0; i < nums1.Length; i++)
        {
            arr[nums1[i]]++;
        }

        var result = new List<int>();
        for (int i = 0; i < nums2.Length; i++)
        {
            if (arr[nums2[i]] > 0)
            {
                arr[nums2[i]]--;
                result.Add(nums2[i]);
            }
        }

        return result.ToArray();
    }

    public int[] Intersect2(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);

        var set = new List<int>();
        int a = 0;
        int b = 0;

        while (a < nums1.Length && b < nums2.Length)
        {
            if (nums1[a] == nums2[b])
            {
                set.Add(nums1[a]);
                a++;
                b++;
            }
            else if (nums1[a] < nums2[b])
            {
                a++;
            }
            else
            {
                b++;
            }
        }

        return set.ToArray();
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }, new int[] { 2, 2 })]
    [InlineData(new int[] { 1 }, new int[] { 3 }, new int[] { })]
    [InlineData(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }, new int[] { 4, 9 })]
    [InlineData(new int[] { 4, 9, 5, 9 }, new int[] { 9, 4, 9, 8, 4 }, new int[] { 4, 9, 9 })]
    [InlineData(new int[] { 1000, 1000, 1000 }, new int[] { 1000 }, new int[] { 1000 })]
    public void IntersectionTests(int[] nums1, int[] nums2, int[] expected)
    {
        // Arrange
        // Act
        // Assert
        AssertUtils.AssertTwoArraysIsEqualWithoutOrder(expected, Intersect(nums1, nums2));
    }

}
