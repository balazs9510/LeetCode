using Xunit;

namespace LeetCodeChallenges.Utils;

public static class AssertUtils
{
    public static void AssertTwoLinkedListIsEqual(ListNode expected, ListNode result)
    {
        while (result != null)
        {
            Assert.Equal(expected.val, result.val);
            result = result.next;
            expected = expected.next;
        }

        Assert.Null(result);
        Assert.Null(expected);
    }

    public static void AssertTwoListIsEqual<T>(List<T> expected, List<T> result)
    {
        Assert.Equal(expected.Count, result.Count);

        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }
}
