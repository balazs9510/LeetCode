using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
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
    public class Binary_Tree_Level_Order_Traversal
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var result = new Dictionary<int, List<int>>();
            RecursiveTravelsar(root, 0, result);

            var list = result.ToArray().Select(x => x.Value).ToArray();
            return list;
        }

        private void RecursiveTravelsar(TreeNode node, int depth, Dictionary<int, List<int>> values)
        {
            if (node == null) return;

            if (values.ContainsKey(depth))
            {
                values[depth].Add(node.val);
            }
            else
            {
                values.Add(depth, new List<int> { node.val });
            }

            RecursiveTravelsar(node.left, depth + 1, values);
            RecursiveTravelsar(node.right, depth + 1, values);
        }

        [Fact]
        public void LevelOrderTests()
        {
            // Arrange 
            var root = new TreeNode
            {
                val = 3,
                left = new TreeNode(9),
                right= new TreeNode
                {
                    val = 20,
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            // act
            var res = LevelOrder(root);

            // Assert
            // Assert.Equal(expected, res);
        }
    }
}
