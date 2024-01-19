using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Medium;

public class Lowest_Common_Ancestor_of_a_Binary_Search_Tree
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root.val > p.val && root.val > q.val)
            return LowestCommonAncestor(root.left, p, q);
        if (root.val < p.val && root.val < q.val)
            return LowestCommonAncestor(root.right, p, q);
        return root;
    }

    // First try
    public TreeNode LowestCommonAncestorByAncestorList(TreeNode root, TreeNode p, TreeNode q)
    {
        var pAncestors = FindAncestors(root, p);
        var qAncestors = FindAncestors(root, q);   

        return pAncestors.Intersect(qAncestors).First();
    }

    private List<TreeNode> FindAncestors(TreeNode root, TreeNode toFind)
    {
        if (root == null) return new List<TreeNode> { };

        if (root.val == toFind.val) return new List<TreeNode> { toFind };

        var move = root.val < toFind.val ? root.right : root.left;
        var found = FindAncestors(move, toFind);
        if (found.Count > 0)
        {
            found.Add(root);
        }
        return found;
    }

    [Fact]
    public void LowestCommonAncestorTest1()
    {
        // Arrange
        var root = new TreeNode(6,
            new TreeNode(2,
                new TreeNode(0),
                new TreeNode(4,
                    new TreeNode(3),
                    new TreeNode(5))),
            new TreeNode(8,
                new TreeNode(7),
                new TreeNode(9)));

        // Act
        var result = LowestCommonAncestor(root, new TreeNode(2), new TreeNode(8));

        // Assert
        Assert.Equal(6, result.val);
    }

    [Fact]
    public void LowestCommonAncestorTest2()
    {
        // Arrange
        var root = new TreeNode(6,
            new TreeNode(2,
                new TreeNode(0),
                new TreeNode(4,
                    new TreeNode(3),
                    new TreeNode(5))),
            new TreeNode(8,
                new TreeNode(7),
                new TreeNode(9)));

        // Act
        var result = LowestCommonAncestor(root, new TreeNode(3), new TreeNode(5));

        // Assert
        Assert.Equal(4, result.val);
    }
}
