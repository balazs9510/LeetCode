using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Intersection_of_Two_Arrays
{
    // O(N + M)
    public int[] Intersection3(int[] nums1, int[] nums2)
    {
        // 1 <= nums1.length, nums2.length <= 1000
        // 0 <= nums1[i], nums2[i] <= 1000
        var arr = new int[1000];
        var set = new HashSet<int>();
        for (int i = 0; i < nums1.Length; i++)
        {
            // used that: 0 <= nums1[i], nums2[i] <= 1000
            arr[nums1[i]]++;
        }

        for (int i = 0; i < nums2.Length; i++)
        {
            if (arr[nums2[i]] > 0) set.Add(nums2[i]);
        }

        // OrderBy for testing only
        return set.OrderBy(x => x).ToArray();
    }

    // O(N + min(N, M))
    public int[] Intersection2(int[] nums1, int[] nums2)
    {
        return nums1.ToList().Intersect(nums2).ToArray();
    }

    //O(N log N + M log M)
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);

        var set = new HashSet<int>();
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
    [InlineData(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }, new int[] { 2 })]
    [InlineData(new int[] { 1 }, new int[] { 3 }, new int[] { })]
    [InlineData(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }, new int[] { 4, 9 })]
    [InlineData(new int[] { 4, 9, 5, 9 }, new int[] { 9, 4, 9, 8, 4 }, new int[] { 4, 9 })]
    public void IntersectionTests(int[] nums1, int[] nums2, int[] expected)
    {
        // Arrange
        // Act
        // Assert
        AssertUtils.AssertTwoArraysIsEqual(expected, Intersection3(nums1, nums2));
    }
}
