using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Invert_Binary_Tree
{
    public TreeNode InvertTree(TreeNode root)
    {
		if (root == null) return null;
		var temp = root.left;
		root.left = root.right;
		root.right = temp;
		InvertTree(root.left);
		InvertTree(root.right);

		return root;
    }


	[Theory]
	[MemberData(nameof(TestDatas))]
	public void InvertTreeTests(TreeNode root, TreeNode expected)
	{
		AssertUtils.AssertBinaryTreeEqual(expected, InvertTree(root));
	}

	public static IEnumerable<object[]> TestDatas => new List<object[]>
	{
		new object[] {
			new TreeNode(4,
				new TreeNode(2,
					new TreeNode(1),
					new TreeNode(3)),
				new TreeNode(7,
					new TreeNode(6),
					new TreeNode(9))),
            new TreeNode(4,
                new TreeNode(7,
                    new TreeNode(9),
                    new TreeNode(6)),
                new TreeNode(2,
                    new TreeNode(3),
                    new TreeNode(1))),
            },
		new object[]
		{
			new TreeNode(2,
				new TreeNode(1),
				new TreeNode(3)),
            new TreeNode(2,
                new TreeNode(3),
                new TreeNode(1)),
        }
	};
}
