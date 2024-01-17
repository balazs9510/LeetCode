using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Merge_Two_Binary_Trees
{
    public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        if (root1 == null && root2 == null) { return null; }
        if (root1 == null) return root2;
        if (root2 == null) return root1;

        var newNode = new TreeNode(root1.val + root2.val);

        newNode.left =  MergeTrees(root1.left, root2.left);
        newNode.right = MergeTrees(root1.right, root2.right);

        return newNode;
    }


    [Fact]
    public void MergeTreesTests()
    {
        // Arrange
        var root1 = new TreeNode(1,
            new TreeNode(3, new TreeNode(5), null),
            new TreeNode(2));
        var root2 = new TreeNode(2,
            new TreeNode(1, null, new TreeNode(4)),
            new TreeNode(3, null, new TreeNode(7)));

        var expected = new TreeNode(3,
            new TreeNode(4, new TreeNode(5), new TreeNode(4)),
            new TreeNode(5, null, new TreeNode(7)));

        // Act
        var result = MergeTrees(root1, root2);

        // Assert
        AssertTreeEqual(expected, result);
    }


    [Fact]
    public void MergeTreesTests1()
    {
        // Arrange
        var root1 = new TreeNode(1);
        var root2 = new TreeNode(1, new TreeNode(2));

        var expected = new TreeNode(2, new TreeNode(2));

        // Act
        var result = MergeTrees(root1, root2);

        // Assert
        AssertTreeEqual(expected, result);
    }

    private void AssertTreeEqual(TreeNode expected, TreeNode result)
    {
        if (expected == null && result == null) { return; }

        Assert.Equal(expected?.val, result?.val);

        AssertTreeEqual(expected?.left, result?.left);
        AssertTreeEqual(expected?.right, result?.right);
    }
}
