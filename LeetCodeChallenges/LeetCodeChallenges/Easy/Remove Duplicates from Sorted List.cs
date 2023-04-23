using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Remove_Duplicates_from_Sorted_List
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


        public ListNode DeleteDuplicates(ListNode head)
        {
            var iterator = head;

            while (iterator != null && iterator.next != null)
            {
                if (iterator.next.val == iterator.val)
                {
                    iterator.next = iterator.next.next;
                }
                else
                {
                    iterator = iterator.next;
                }
            }
            return head;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void DeleteDuplicatesTests(ListNode head, ListNode expected)
        {
            // Arrance & Act
            var res = DeleteDuplicates(head);

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
                new object[] { TestData1(), TestDataExpected1()},
                new object[] { TestData2(), TestDataExpected2()},
                new object[] { TestData3(), TestDataExpected3()},
           };
        }

        public static ListNode TestData1()
        {
            var head = new ListNode { val = 1 };
            head.next = new ListNode { val = 1 };
            head.next.next = new ListNode { val = 2 };
            return head;
        }
        public static ListNode TestDataExpected1()
        {
            var head = new ListNode { val = 1 };
            head.next = new ListNode { val = 2 };
            return head;
        }

        public static ListNode TestData2()
        {
            var head = new ListNode { val = 1 };
            head.next = new ListNode { val = 1 };
            head.next.next = new ListNode { val = 2 };
            head.next.next.next = new ListNode { val = 3 };
            head.next.next.next.next = new ListNode { val = 3 };
            return head;
        }

        public static ListNode TestDataExpected2()
        {
            var head = new ListNode { val = 1 };
            head.next = new ListNode { val = 2 };
            head.next.next = new ListNode { val = 3 };

            return head;
        }

        public static ListNode TestData3()
        {
            var head = new ListNode { val = 1 };
            head.next = new ListNode { val = 1 };
            head.next.next = new ListNode { val = 1 };
            return head;
        }
        public static ListNode TestDataExpected3()
        {
            var head = new ListNode { val = 1 };
            return head;
        }
    }
}
