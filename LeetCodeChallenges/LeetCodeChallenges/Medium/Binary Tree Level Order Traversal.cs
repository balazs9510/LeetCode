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
        public class LeveledNode
        {
            public TreeNode Node { get; set; }
            public int Level { get; set; }
        }
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            //var result = new Dictionary<int, List<int>>();
            //RecursiveTravelsar(root, 0, result);

            //var list = result.ToArray().Select(x => x.Value).ToArray();
            //return list;

            // BFS solution
            var result = new List<IList<int>>();
            var levelNodes = new List<int>();
            var queue = new Queue<LeveledNode>();
            queue.Enqueue(new LeveledNode { Node = root, Level = 0 });
            var level = 0;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Level != level && levelNodes.Count > 0)
                {
                    result.Add(levelNodes.ToArray());
                    levelNodes = new List<int>();
                }

                level = current.Level;
                if (current.Node is not null)
                {
                    levelNodes.Add(current.Node.val);
                    queue.Enqueue(new LeveledNode { Level = current.Level + 1, Node = current.Node.left });
                    queue.Enqueue(new LeveledNode { Level = current.Level + 1, Node = current.Node.right });
                }
            }

            return result;
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
                right = new TreeNode
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
