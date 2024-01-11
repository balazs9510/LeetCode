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
}
