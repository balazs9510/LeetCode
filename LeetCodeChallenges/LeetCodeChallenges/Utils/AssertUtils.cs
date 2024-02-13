using LeetCodeChallenges.Easy;
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

    public static void AssertTwoArraysIsEqualWithoutOrder(int[] expected, int[] result)
    {
        Array.Sort(expected);
        Array.Sort(result);
        AssertTwoListIsEqual(expected.ToList(), result.ToList());
    }

    public static void AssertTwoArraysIsEqual(int[] expected, int[] result) => AssertTwoListIsEqual(expected.ToList(), result.ToList());

    public static void AssertTwoListIsEqual<T>(List<T> expected, List<T> result)
    {
        Assert.Equal(expected.Count, result.Count);

        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }

    public static void AssertBinaryTreeEqual(TreeNode expected, TreeNode result)
    {
        var algo = new Binary_Tree_Inorder_Traversal();
        var expectedList = algo.InorderTraversal(expected).ToList();
        var resultList = algo.InorderTraversal(result).ToList();
        AssertTwoListIsEqual(expectedList, resultList);
    }
}
