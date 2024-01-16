using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Binary_Tree_Inorder_Traversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            var iterator = root;
            while (iterator != null || stack.Count > 0)
            {
                while (iterator != null)
                {
                    stack.Push(iterator);
                    iterator = iterator.left;
                }

                iterator = stack.Pop();
                result.Add(iterator.val);
                iterator = iterator.right;
            }
            return result;
        }

        public IList<int> InorderTraversalRec(TreeNode root)
        {
            var result = new List<int>();
            if (root is not null)
                InorderTraversalRecStep(root, result);
            return result;
        }

        private void InorderTraversalRecStep(TreeNode node, IList<int> resultList)
        {
            if (node.left is not null)
            {
                InorderTraversalRecStep(node.left, resultList);
            }

            resultList.Add(node.val);

            if (node.right is not null)
            {
                InorderTraversalRecStep(node.right, resultList);
            }
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var root = new TreeNode(1, null, new TreeNode(2, new TreeNode(3), null));

            // Act
            var result = InorderTraversal(root);
            var resultAsString = string.Join(",", result);

            // Assert
            Assert.Equal("1,3,2", resultAsString);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var root = new TreeNode(1);

            // Act
            var result = InorderTraversal(root);
            var resultAsString = string.Join(",", result);

            // Assert
            Assert.Equal("1", resultAsString);
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            var root = new TreeNode
                (
                    6,
                    new TreeNode(3, new TreeNode(2), new TreeNode(1)),
                    new TreeNode(
                        10,
                        new TreeNode(
                            9,
                            null,
                            new TreeNode(
                                8,
                                null,
                                new TreeNode(30))),
                        null)
                );

            // Act
            var result = InorderTraversal(root);
            var resultAsString = string.Join(",", result);

            // Assert
            Assert.Equal("2,3,1,6,9,8,30,10", resultAsString);
        }
    }
}
