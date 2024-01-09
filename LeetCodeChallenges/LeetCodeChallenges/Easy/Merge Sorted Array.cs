using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Merge_Sorted_Array
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int n1I = 0, n2I = 0, rI = 0;
            int[] result = new int[n + m];
            while (n1I < m && n2I < n)
            {
                if (nums1[n1I] < nums2[n2I])
                {
                    result[rI] = nums1[n1I++];
                }
                else
                {
                    result[rI] = nums2[n2I++];
                }
                rI++;
            }

            while (n1I < m)
            {
                result[rI++] = nums1[n1I++];
            }

            while (n2I < n)
            {
                result[rI++] = nums2[n2I++];
            }

            Array.Copy(result, nums1, nums1.Length);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 0, 0, 0 }, new int[] { 2, 5, 6 })]
        [InlineData(new int[] { 1 }, new int[] { })]
        [InlineData(new int[] { 1 }, new int[] { 0 })]
        [InlineData(new int[] { 0 }, new int[] { 1 })]
        [InlineData(new int[] { 0, 0 }, new int[] { 2, 3 })]
        public void LastStoneWeightTests(int[] nums1, int[] nums2)
        {
            // Arrange & act
            Merge(nums1, nums1.Length - nums2.Length, nums2, nums2.Length);

            // Assert
            var prev = nums1[0];
            for (int i = 1; i < nums1.Length; i++)
            {
                var current = nums1[i];
                Assert.True(prev <= current);
                prev = current;
            }
        }
    }
}
