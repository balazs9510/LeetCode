using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Diameter_of_Binary_Tree
{
    public int DiameterOfBinaryTree(TreeNode root)
    {
        int max = 0;
        //var leftSize = GetLevels(root.left, max);
        //var rightSize = GetLevels(root.right);
        GetLevels(root, ref max);
        //return leftSize + rightSize;

        return max;
    }

    public int GetLevels(TreeNode root, ref int max)
    {
        if (root is null) return 0;
        if (root.left is null && root.right is null) return 1;

        int leftSize = 0; int rightSize = 0;
        if (root.left is not null)
            leftSize = GetLevels(root.left, ref max);
        if (root.right is not null)
            rightSize = GetLevels(root.right, ref max);

        max = Math.Max(max, leftSize + rightSize);

        return Math.Max(leftSize + 1, rightSize + 1);
    }

    [Theory]
    [MemberData(nameof(TestDatas))]
    public void DiameterOfBinaryTreeTests(TreeNode root, int expected)
    {
        Assert.Equal(expected, DiameterOfBinaryTree(root));
    }

    // [3,1,null,null,2]
    public static IEnumerable<object[]> TestDatas => new List<object[]>
    {
        new object[] {
            new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4),
                    new TreeNode(5)),
                new TreeNode(3)),
            3
        },
        new object[]
        {
            new TreeNode(1,
                new TreeNode(2)),
            1,
        },
        new object[]
        {
            new TreeNode(3,
               new TreeNode(1,
                   null,
                   new TreeNode(2)),
               null),
            2,
        },
        new object[]
        {
            new TreeNode(4,
               new TreeNode(-7),
               new TreeNode(-3,
                   new TreeNode(-9,
                       new TreeNode(9,
                           new TreeNode(6,
                               new TreeNode(0,
                                   null,
                                   new TreeNode(-1)),
                               new TreeNode(6,
                                   new TreeNode(-4)))),
                       new TreeNode(-7,
                           new TreeNode(-6,
                               new TreeNode(5)),
                           new TreeNode(-6,
                               new TreeNode(9,
                                   new TreeNode(2))))),
                   new TreeNode(-3,
                       new TreeNode(-4)))),
            8
        }
    };
}
