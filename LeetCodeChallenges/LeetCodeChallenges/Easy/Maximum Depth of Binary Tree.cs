using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy
{

    public class Maximum_Depth_of_Binary_Tree
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

        public int MaxDepth(TreeNode root)
        {
            if (root is null) return 0;

            return MaxDepthRec(root, 1);
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
