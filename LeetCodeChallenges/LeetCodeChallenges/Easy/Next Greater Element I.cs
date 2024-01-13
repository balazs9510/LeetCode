using Xunit;

namespace LeetCodeChallenges.Easy;

public class Next_Greater_Element_I
{
    // TODO: the problem asks for O(N+M)
    // O(N*M)
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        int[] result = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            int current = nums1[i];
            int? greater = null;
            for (int j = 0; j < nums2.Length; j++)
            {
                if (nums2[j] == current)
                {
                    greater = -1;
                }
                else if (greater == -1 && nums2[j] > current)
                {
                    greater = nums2[j];
                }
            }

            result[i] = greater!.Value;
        }

        return result;
    }


    [Theory]
    [InlineData(new int[] { 4, 1, 2 }, new int[] { 1, 3, 4, 2 }, new int[] { -1, 3, -1 })]
    [InlineData(new int[] { 2, 4 }, new int[] { 1, 2, 3, 4 }, new int[] { 3, -1 })]
    [InlineData(new int[] { 1, 3, 5, 10 }, new int[] { 1, 3, 5, 10, 11 }, new int[] { 3, 5, 10, 11 })]
    public void NextGreaterElementTests(int[] nums1, int[] nums2, int[] expected)
    {
        // Arrange
        // Act
        var result = NextGreaterElement(nums1, nums2);

        // Assert
        for (var i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }
}
