using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy
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

    public class Same_Tree
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;

            if (p?.val != q?.val) return false;

            var result = IsSameTree(p.left, q.left);

            return result && IsSameTree(p.right, q.right);
        }

        [Fact]
        public void Test()
        {
            // Arrange
            var p = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            var q = new TreeNode(1, new TreeNode(2), new TreeNode(3));
            
            // Act
            var result = IsSameTree(p, q);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var p = new TreeNode(1, new TreeNode(2), null);
            var q = new TreeNode(1, null, new TreeNode(2));

            // Act
            var result = IsSameTree(p, q);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var p = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            var q = new TreeNode(1, new TreeNode(2), new TreeNode(3));

            // Act
            var result = IsSameTree(p, q);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Test3()
        {
            // Arrange
            var p = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            var q = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));

            // Act
            var result = IsSameTree(p, q);

            // Assert
            Assert.True(result);
        }
    }
}

