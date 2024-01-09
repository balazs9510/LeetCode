using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Remove_Nth_Node_From_End_of_List0
    {

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var index = 0;
            var iterator = head;
            var dict = new Dictionary<int, ListNode>();
            while (iterator != null)
            {
                dict.Add(index++, iterator);
                iterator = iterator.next;
            }
            var prev = dict.Count - n - 1;
            if (prev < 0)
            {
                return head.next;
            }
            else
            {
                dict[prev].next = dict[prev + 1].next;
            }

            return head;
        }
        [Theory]
        [MemberData(nameof(Data))]
        public void RemoveNthFromEndTests(ListNode head, int n, ListNode expected)
        {
            // Arrance & Act
            var res = RemoveNthFromEnd(head, n);

            // Assert
            while (expected != null)
            {
                Assert.Equal(expected.val, res.val);
                expected = expected.next;
                res = res.next;
            }

            Assert.Null(res);
            Assert.Null(expected);
        }

        public static IEnumerable<object[]> Data()
        {
            return new List<object[]>
           {
                new object[] { TestData1(), 2, TestDataExpected1()},
                new object[] { TestData2(), 1, TestDataExpected2()},
                new object[] { TestData3(), 1, TestDataExpected3()},
           };
        }

        public static ListNode TestData1()
        {
            var head = new ListNode { val = 1 };
            head.next = new ListNode { val = 2 };
            head.next.next = new ListNode { val = 3 };
            head.next.next.next = new ListNode { val = 4 };
            head.next.next.next.next = new ListNode { val = 5 };
            return head;
        }
        public static ListNode TestDataExpected1()
        {
            var head = new ListNode { val = 1 };
            head.next = new ListNode { val = 2 };
            head.next.next = new ListNode { val = 3 };
            head.next.next.next = new ListNode { val = 5 };
            return head;
        }
        public static ListNode TestData2()
        {
            var head = new ListNode { val = 1 };

            return head;
        }
        public static ListNode TestDataExpected2()
        {
            return null;
        }
        public static ListNode TestData3()
        {
            var head = new ListNode { val = 1 };
            head.next = new ListNode { val = 2 };

            return head;
        }
        public static ListNode TestDataExpected3()
        {
            var head = new ListNode { val = 1 };

            return head;
        }

    }
}
