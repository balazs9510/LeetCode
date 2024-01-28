using Xunit;

namespace LeetCodeChallenges.Easy;

public class Next_Greater_Element_I
{
    // Using monotonic stack
    // O(N+M)
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var monoStack = new Stack<int>();
        var dict = new Dictionary<int, int>();
        var result = new int[nums1.Length];
        for (int i = nums2.Length - 1; i >= 0; i--)
        {
            var num = nums2[i];
            while (monoStack.Count > 0 && monoStack.Peek() <= num)
            {
                monoStack.Pop();
            }

            dict.Add(num, monoStack.Count > 0 ? monoStack.Peek() : -1); // save the greatest before adding 
            monoStack.Push(num);
        }

        for (int i = 0; i < nums1.Length; i++)
        {
            result[i] = dict[nums1[i]];
        }

        return result;
    }

    // O(N*M)
    public int[] NextGreaterElement1(int[] nums1, int[] nums2)
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
