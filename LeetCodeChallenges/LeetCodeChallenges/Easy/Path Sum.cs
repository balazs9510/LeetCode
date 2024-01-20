
using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Path_Sum
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root is null) return false;
        if (root.left is null && root.right is null) return root?.val == targetSum;

        var diff = targetSum - root.val;
        if (root.right is null) return HasPathSum(root.left, diff);
        if (root.left is null) return HasPathSum(root.right, diff);


        return HasPathSum(root.left, diff) || HasPathSum(root.right, diff);
    }


    [Fact]
    public void HasPathSumTest1()
    {
        // Arrange
        var root = new TreeNode(5,
            new TreeNode(4,
                new TreeNode(11,
                    new TreeNode(7),
                    new TreeNode(2)),
                null),
            new TreeNode(8,
                new TreeNode(13),
                new TreeNode(4,
                    new TreeNode(1))));

        // Act
        var result = HasPathSum(root, 22);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasPathSumTest2()
    {
        // Arrange
        var root = new TreeNode(1,
            new TreeNode(2),
            new TreeNode(3));

        // Act
        var result = HasPathSum(root, 5);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasPathSumTest3()
    {
        // Arrange

        // Act
        var result = HasPathSum(null, 0);

        // Assert
        Assert.False(result);
    }
}
