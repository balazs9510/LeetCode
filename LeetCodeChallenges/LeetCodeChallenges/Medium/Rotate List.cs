using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Rotate_List
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

        public ListNode RotateRight(ListNode head, int k)
        {
            if (head == null) return null;

            var listOfItems = new List<ListNode>();
            var iterator = head;
            while (iterator != null)
            {
                listOfItems.Add(iterator);
                iterator = iterator.next;
            }
            k = k % listOfItems.Count;
            if (k == 0) return head;

            var itemCount = listOfItems.Count;
            var newRoot = listOfItems[itemCount - k];
            var parentOfNewRoot = listOfItems[itemCount - k - 1];
            parentOfNewRoot.next = null;
            listOfItems[itemCount - 1].next = head;

            return newRoot;
        }


        [Fact]
        public void MyTestMethod()
        {
            // Arrange
            var root = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            var r = 2;

            // Act
            var result = RotateRight(root, r);

            // Assert
            Assert.Equal(4, result.val);
            Assert.Equal(5, result.next.val);
            Assert.Equal(1, result.next.next.val);
            Assert.Equal(2, result.next.next.next.val);
            Assert.Equal(3, result.next.next.next.next.val);
        }


        [Fact]
        public void MyTestMethod2()
        {
            // Arrange
            var root = new ListNode(0, new ListNode(1, new ListNode(2)));
            var r = 4;

            // Act
            var result = RotateRight(root, r);

            // Assert
            Assert.Equal(2, result.val);
            Assert.Equal(0, result.next.val);
            Assert.Equal(1, result.next.next.val);
        }

        [Fact]
        public void MyTestMethod3()
        {
            // Arrange
            var root = new ListNode(0, new ListNode(1, new ListNode(2)));
            var r = 3;

            // Act
            var result = RotateRight(root, r);

            // Assert
            Assert.Equal(0, result.val);
            Assert.Equal(1, result.next.val);
            Assert.Equal(2, result.next.next.val);
        }
    }
}
