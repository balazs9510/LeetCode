using LeetCodeChallenges.Medium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Easy
{
    public class Symmetric_Tree
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
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return IsSymmetricRec(root.left, root.right);
        }

        private bool IsSymmetricRec(TreeNode node1, TreeNode node2)
        {

            if (node1 == null && node2 == null) return true;
            if ((node1 == null && node2 != null) || (node1 != null && node2 == null)) return false;

            if (node1.val != node2.val) return false;

            var l = IsSymmetricRec(node1.left, node2.right);
            var r = IsSymmetricRec(node1.right, node2.left);

            return l && r;
        }
    }
}
