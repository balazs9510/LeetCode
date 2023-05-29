using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Copy_List_with_Random_Pointer
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }

            public Node(int _val, Node _random)
            {
                val = _val;
                next = null;
                random = _random;
            }
        }

        public Node CopyRandomList(Node head)
        {

            if (head is null) return null;

            var mapping = new Dictionary<Node, Node>();
            var iterator = head;

            while (iterator != null)
            {
                var newNode = new Node(iterator.val);
                mapping.Add(iterator, newNode);

                iterator = iterator.next;
            }

            iterator = head;
            while (iterator != null)
            {
                var newNode = mapping[iterator];

                if (iterator.next is Node)
                    newNode.next = mapping[iterator.next];

                if (iterator.random is Node)
                    newNode.random = mapping[iterator.random];

                iterator = iterator.next;
            }

            return mapping.First().Value;
        }

        [Fact]
        public void CopyRandomListTest()
        {
            var node0 = new Node(7);
            var node1 = new Node(13);
            node0.next = node1;
            node1.random = node0;
            var node2 = new Node(11);
            node1.next = node2;
            var node3 = new Node(10);
            node2.next = node3;
            node3.random = node2;
            var node4 = new Node(1);
            node3.next = node4;
            node4.random = node0;
            node2.random = node4;
            var newHead = CopyRandomList(node0);
        }
    }
}
