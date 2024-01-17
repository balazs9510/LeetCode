using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Remove_Linked_List_Elements
{
    public ListNode RemoveElements(ListNode head, int val)
    {
        ListNode dummy = new ListNode(-1, head);
        var iterator = dummy;

        while (iterator != null)
        {
            while (iterator.next?.val == val)
            {
                iterator.next = iterator.next.next;
            }

            iterator = iterator.next;
        }
        return dummy.next;
    }


    [Fact]
    public void RemoveElementsTest1()
    {
        // Arrange
        var head = ListNode.CreateOrderedFrom(1, 2, 6, 3, 4, 5, 6);
        var expected = ListNode.CreateOrderedFrom(1, 2, 3, 4, 5);
        // Act
        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, RemoveElements(head, 6));
    }

    [Fact]
    public void RemoveElementsTest2()
    {
        // Arrange
        var head = ListNode.CreateOrderedFrom();
        var expected = ListNode.CreateOrderedFrom();
        // Act
        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, RemoveElements(head, 1));
    }

    [Fact]
    public void RemoveElementsTest3()
    {
        // Arrange
        var head = ListNode.CreateOrderedFrom(7, 7, 7, 7);
        var expected = ListNode.CreateOrderedFrom();
        // Act
        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, RemoveElements(head, 7));
    }
}
