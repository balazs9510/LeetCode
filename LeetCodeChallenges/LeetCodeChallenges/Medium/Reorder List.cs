using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Medium;

public class Reorder_List
{
    public void ReorderList(ListNode head)
    {
        ListNode fast = head;
        ListNode slow = head;
        // reach the half of the elements
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode half = slow.next;
        // cut the ref for the numbers to be inserted
        slow.next = null;
        ListNode prev = null;
        // reverse the last half of the elements
        while (half != null)
        {
            var temp = half.next;
            half.next = prev;
            prev = half;
            half = temp;
        }

        ListNode first = head;
        ListNode second = prev;

        while (second != null)
        {
            var t1 = first.next;
            var t2 = second.next;
            first.next = second;
            second.next = t1;
            first = t1;
            second = t2;
        }
    }

    public void ReorderListStack(ListNode head)
    {
        var stack = new Stack<ListNode>();
        var iterator = head;

        while (iterator != null)
        {
            stack.Push(iterator);
            iterator = iterator.next;
        }

        iterator = head;
        var stackCount = stack.Count;
        var insertCount = 0;
        var toInsert = stackCount % 2 == 0 ? stackCount / 2 : stackCount / 2 - 1; ;
        while (insertCount <= toInsert)
        {
            var insert = stack.Pop();
            insert.next = iterator.next;
            iterator.next = insert;
            iterator = insert.next;
            insertCount++;
        }

        if (iterator is not null)
            iterator.next = null;
    }


    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 4, 2, 3 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 5, 2, 4, 3 })]
    public void ReorderListTests(int[] nums, int[] expectedNums)
    {
        // Arrange
        var head = ListNode.CreateOrderedFrom(nums);
        var expected = ListNode.CreateOrderedFrom(expectedNums);
        // Act
        ReorderList(head);

        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, head);
    }
}
