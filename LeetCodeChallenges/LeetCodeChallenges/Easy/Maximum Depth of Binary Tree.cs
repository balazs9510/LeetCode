using Xunit;
using LeetCodeChallenges.Utils;

namespace LeetCodeChallenges.Easy
{
    public record LevelDecorator(TreeNode node, int level);
    //    : TreeNode
    //{
    //    public readonly TreeNode node;
    //    public readonly int level;

    //    public LevelDecorator(TreeNode node, int level)
    //    {
    //        this.node = node;
    //        this.level = level;
    //    }
    //};

    public class Maximum_Depth_of_Binary_Tree
    {
        public int MaxDepth(TreeNode root)
        {
            if (root is null) return 0;

            return MaxDepthIterative(root);
        }

        public int MaxDepthIterative(TreeNode root)
        {
            var stack = new Stack<LevelDecorator>();
            stack.Push(new LevelDecorator(root, 1));
            int max = 1;
            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current.level > max) max = current.level;

                if (current.node.right is not null)
                {
                    stack.Push(new LevelDecorator(current.node.right, current.level + 1));
                }

                if (current.node.left is not null)
                {
                    stack.Push(new LevelDecorator(current.node.left, current.level + 1));
                }
            }

            return max;
        }

        public int MaxDepthRec(TreeNode root, int current)
        {
            if (root.left is null && root.right is null) return current;

            var leftSize = 0;
            if (root.left != null)
            {
                leftSize = MaxDepthRec(root.left, current + 1);
            }
            var rightSize = 0;
            if (root.right != null)
            {
                rightSize = MaxDepthRec(root.right, current + 1);
            }
            return leftSize > rightSize ? leftSize : rightSize;
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var root = new TreeNode(
                3,
                new TreeNode(9),
                new TreeNode(
                    20,
                    new TreeNode(15),
                    new TreeNode(7)
                ));

            // Act
            var result = MaxDepth(root);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var root = new TreeNode(
                1,
                null,
                new TreeNode(9)
                );

            // Act
            var result = MaxDepth(root);

            // Assert
            Assert.Equal(2, result);
        }

    }
}
