using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Binary_Tree_Inorder_Traversal
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

        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            if (root is not null)
                InorderTraversalRec(root, result);
            return result;
        }

        private void InorderTraversalRec(TreeNode node, IList<int> resultList)
        {
            if (node.left is not null)
            {
                InorderTraversalRec(node.left, resultList);
            }

            resultList.Add(node.val);

            if (node.right is not null)
            {
                InorderTraversalRec(node.right, resultList);
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
