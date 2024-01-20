using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Medium;

public class Add_Two_Numbers
{

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        bool rem = false;
        ListNode newNode = new ListNode(-1);
        ListNode iterator = newNode;
        while (!(l1 == null && l2 == null))
        {
            int current = rem ? 1 :0;
            if (l1 is not null) current += l1.val;
            if (l2 is not null) current += l2.val;

            rem = current >= 10;
            iterator.next = new ListNode(current % 10);
            iterator = iterator.next;

            if (l1 is not null) l1 = l1.next;
            if (l2 is not null) l2 = l2.next;
        }

        if (rem)
        {
            iterator.next = new ListNode(1);
        }
        return newNode.next;
    }

    [Fact]
    public void AddTwoNumbersTest1()
    {
        // Arrange
        var l1 = ListNode.CreateOrderedFrom(2, 4, 3);
        var l2 = ListNode.CreateOrderedFrom(5, 6, 4);

        var expected = ListNode.CreateOrderedFrom(7, 0, 8);
        // Act
        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, AddTwoNumbers(l1, l2));
    }

    [Fact]
    public void AddTwoNumbersTest2()
    {
        // Arrange
        var l1 = ListNode.CreateOrderedFrom(0);
        var l2 = ListNode.CreateOrderedFrom(0);

        var expected = ListNode.CreateOrderedFrom(0);
        // Act
        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, AddTwoNumbers(l1, l2));
    }

    [Fact]
    public void AddTwoNumbersTest3()
    {
        // Arrange
        var l1 = ListNode.CreateOrderedFrom(9, 9, 9, 9, 9, 9, 9);
        var l2 = ListNode.CreateOrderedFrom(9, 9, 9, 9);

        var expected = ListNode.CreateOrderedFrom(8, 9, 9, 9, 0, 0, 0, 1);
        // Act
        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, AddTwoNumbers(l1, l2));
    }

    [Fact]
    public void AddTwoNumbersTest4()
    {
        // Arrange
        var l1 = ListNode.CreateOrderedFrom(9);
        var l2 = ListNode.CreateOrderedFrom(9);

        var expected = ListNode.CreateOrderedFrom(8,1);
        // Act
        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, AddTwoNumbers(l1, l2));
    }
}