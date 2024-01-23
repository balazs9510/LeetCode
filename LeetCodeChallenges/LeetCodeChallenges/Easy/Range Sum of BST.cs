using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Range_Sum_of_BST
{
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        if (root is null) return 0;

        if (root.val > high) return RangeSumBST(root.left, low, high);
        if (root.val < low) return RangeSumBST(root.right, low, high);
        var left = RangeSumBST(root.left, low, high);
        var right = RangeSumBST(root.right, low, high);

        return left + right + root.val;
    }


    [Fact]
    public void RangeSumBSTTest1()
    {
        // Arrange
        var root = new TreeNode(10,
            new TreeNode(5,
                new TreeNode(3),
                new TreeNode(7)),
            new TreeNode(15,
                null,
                new TreeNode(18)));

        // Act
        // Assert
        Assert.Equal(32, RangeSumBST(root, 7, 15));
    }

    [Fact]
    public void RangeSumBSTTest2()
    {
        // Arrange
        var root = new TreeNode(10,
            new TreeNode(5,
                new TreeNode(3, new TreeNode(1)),
                new TreeNode(7, new TreeNode(6))),
            new TreeNode(15,
                new TreeNode(13),
                new TreeNode(18)));

        // Act
        // Assert
        Assert.Equal(23, RangeSumBST(root, 6, 10));
    }
}
