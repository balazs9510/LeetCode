using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Medium;

public class Flatten_Binary_Tree_to_Linked_List
{
    public void Flatten(TreeNode root)
    {
        if (root == null) return;
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        var prev = new TreeNode(-1);
        while (stack.Count > 0)
        {
            var current = stack.Pop();

            if (current.right != null)
                stack.Push(current.right);
            if (current.left != null)
                stack.Push(current.left);

            prev.right = current;
            current.left = null;
            prev.left = null;
            prev = prev.right;
        }
    }


    [Fact]
    public void FlattenTest1()
    {
        // Arrange
        var root = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(3),
                new TreeNode(4)),
            new TreeNode(5,
                null,
                new TreeNode(6)));

        var expected = new TreeNode(1,
            null,
            new TreeNode(2,
                null,
                new TreeNode(3,
                    null,
                    new TreeNode(4,
                        null,
                        new TreeNode(5,
                            null,
                            new TreeNode(6)))))
            );
        // Act
        Flatten(root);

        // Assert
        AssertUtils.AssertBinaryTreeEqual(expected, root);
    }

    [Fact]
    public void FlattenTest2()
    {
        // Arrange
        var root = new TreeNode(0);

        var expected = new TreeNode(0);
        // Act
        Flatten(root);

        // Assert
        AssertUtils.AssertBinaryTreeEqual(expected, root);
    }
}
