using Xunit;
using LeetCodeChallenges.Utils;

namespace LeetCodeChallenges.Easy;

public class Binary_Tree_Postorder_Traversal
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        //var result = new List<int>();

        //PostorderTraversalRec(root, result);

        //return result;

        return PostorderTraversalIterative(root);
    }

    private IList<int> PostorderTraversalIterative(TreeNode root)
    {
        var result = new List<int>();
        if (root is null) return result;
        var stack = new Stack<TreeNode>();

        stack.Push(root);
        while (stack.Count > 0)
        {
            var current = stack.Peek();

            if (current.left is null && current.right is null)
            {
                result.Add(stack.Pop().val);
            }
            else
            {
                if (current.right is not null)
                {
                    stack.Push(current.right);
                    current.right = null;
                }

                if (current.left is not null)
                {
                    stack.Push(current.left);
                    current.left = null;
                }
            }
        }

        return result;
    }

    private void PostorderTraversalRec(TreeNode node, List<int> result)
    {
        if (node is null) return;

        if (node.left is null && node.right is null)
        {
            result.Add(node.val);
            return;
        }

        if (node.left is not null)
        {
            PostorderTraversalRec(node.left, result);
        }

        if (node.right is not null)
        {
            PostorderTraversalRec(node.right, result);
        }

        result.Add(node.val);
    }


    [Theory]
    [MemberData(nameof(TestData))]
    public void PostorderTraversalTests(TreeNode root, List<int> expected)
    {
        // Arrange
        // Act
        // Assert
        AssertUtils.AssertTwoListIsEqual(expected, PostorderTraversal(root).ToList());
    }

    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[]{ new TreeNode(1, null, new TreeNode(2, new TreeNode(3))), new List<int> { 3, 2, 1 } },
        new object[]{ null, new List<int> { } },
        new object[]{ new TreeNode(10, new TreeNode(3, new TreeNode(6), new TreeNode(10)), new TreeNode(6, new TreeNode(9, new TreeNode(8), new TreeNode(11)), new TreeNode(53))),
            new List<int> {6,10,3,8,11,9,53,6,10 } }
    };
}
