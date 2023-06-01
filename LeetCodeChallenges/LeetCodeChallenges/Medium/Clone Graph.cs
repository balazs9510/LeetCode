using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Clone_Graph
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        public Node CloneGraph(Node node)
        {
            if (node == null) return null;
            if (node.neighbors.Count == 0) return new Node(node.val);
            var pairs = new Dictionary <int, Node>();

            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                pairs.Add(current.val, new Node(current.val));

                foreach (var neigh in current.neighbors)
                {
                    if (!pairs.ContainsKey(neigh.val) && !queue.Contains(neigh))
                    {
                        queue.Enqueue(neigh);
                    }
                }
            }

            queue.Enqueue(node);

            var visited = new Dictionary<Node, bool>();
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                visited.Add(current, true);
                var pair = pairs[current.val];

                foreach (var neigh in current.neighbors)
                {
                    pair.neighbors.Add(pairs[neigh.val]);
                    if (!queue.Contains(neigh) && !visited.ContainsKey(neigh))
                    {
                        queue.Enqueue(neigh);
                    }
                }
            }

            return pairs.Values.First();
        }

        [Fact]
        public void CloneGraphTest()
        {
            var first = new Node(1);
            var second = new Node(2);
            var third = new Node(3);
            var fourth = new Node(4);

            first.neighbors.Add(second);
            first.neighbors.Add(fourth);

            second.neighbors.Add(first);
            second.neighbors.Add(third);

            third.neighbors.Add(second);
            third.neighbors.Add(fourth);

            fourth.neighbors.Add(first);
            fourth.neighbors.Add(third);

            CloneGraph(first);
        }
    }
}
