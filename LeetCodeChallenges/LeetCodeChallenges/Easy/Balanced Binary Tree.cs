using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Balanced_Binary_Tree
{

    public bool IsBalanced(TreeNode root)
    {
        if (root == null) return true;

        if (GetHeight(root) == -1) return false;

        return true;
    }

    private int GetHeight(TreeNode node)
    {
        if (node is null) return 0;

        var leftHeight = GetHeight(node.left);
        var rightHeight = GetHeight(node.right);

        if (leftHeight == -1 || rightHeight == -1) return -1;
        if (Math.Abs(leftHeight - rightHeight) > 1) return -1;

        return Math.Max(leftHeight, rightHeight) + 1;
    }


    [Fact]
    public void IsBalancedTest1()
    {
        // Arrange
        var root = new TreeNode(3,
            new TreeNode(9),
            new TreeNode(20,
                new TreeNode(15),
                new TreeNode(7)));

        // Act
        // Assert
        Assert.True(IsBalanced(root));
    }

    [Fact]
    public void IsBalancedTest2()
    {
        // Arrange
        var root = new TreeNode(1,
            new TreeNode(2,
                new TreeNode(3,
                    new TreeNode(4),
                    new TreeNode(4)),
                new TreeNode(3)),
            new TreeNode(2));

        // Act
        // Assert
        Assert.False(IsBalanced(root));
    }

    [Fact]
    public void IsBalancedTest3()
    {
        // Arrange
        // Act
        // Assert
        Assert.True(IsBalanced(null));
    }
}
