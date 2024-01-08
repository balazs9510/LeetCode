using Xunit;

namespace LeetCodeChallenges.Easy;


public class Binary_Tree_Preorder_Traversal
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    // Iterative approach practicing Stacks
    public IList<int> PreorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            if (node != null)
            {
                result.Add(node.val);
                stack.Push(node.right);
                stack.Push(node.left);
            }
        }

        return result;
    }

    public IList<int> PreorderTraversalRecursive(TreeNode root)
    {
        return PreorderTraversalRecursiveStep(root, new List<int> { });
    }

    private IList<int> PreorderTraversalRecursiveStep(TreeNode root, IList<int> values)
    {
        if (root == null) return values;

        values.Add(root.val);

        if (root.left != null) PreorderTraversalRecursiveStep(root.left, values);
        if (root.right != null) PreorderTraversalRecursiveStep(root.right, values);

        return values;
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void PreorderTraversalTests(TreeNode root, List<int> expected)
    {
        // Arrange
        // Act
        var result = PreorderTraversal(root);

        // Assert
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }

    [Theory]
    [MemberData(nameof(Data))]
    public void PreorderTraversalRecTests(TreeNode root, List<int> expected)
    {
        // Arrange
        // Act
        var result = PreorderTraversalRecursive(root);

        // Assert
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], result[i]);
        }
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new TreeNode(1, null, new TreeNode(2, new TreeNode(3))), new List<int> { 1,2,3 }  },
            new object[] { null, new List<int> { } },
            new object[] { new TreeNode(1), new List<int> { 1 } },
            new object[] { new TreeNode(1, new TreeNode(6, new TreeNode(7), new TreeNode(8)), new TreeNode(2, new TreeNode(3))), new List<int> { 1,6,7,8,2,3 }  },

        };
}
