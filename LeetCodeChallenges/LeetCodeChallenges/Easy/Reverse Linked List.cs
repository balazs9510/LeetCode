using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Reverse_Linked_List
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

    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        
        while (head != null)
        {
            var temp = prev; 
            prev = head;
            prev.next = temp;
            head = head.next;
        }

        return prev;
    }


    [Fact]
    public void ReverseListTests()
    {
        // Arrange
        var root = new ListNode(1);
        root.next = new ListNode(2);
        root.next.next = new ListNode(3);
        root.next.next.next = new ListNode(4);
        root.next.next.next.next = new ListNode(5);

        var expected = new ListNode(5);
        expected.next = new ListNode(4);
        expected.next.next = new ListNode(3);
        expected.next.next.next = new ListNode(2);
        expected.next.next.next.next = new ListNode(1);

        // Act
        var result = ReverseList(root);

        // Assert
        AssertTwoLinkedListIsEqual(expected, result);
    }


    [Fact]
    public void ReverseListTests2()
    {
        // Arrange
        var root = new ListNode(1);
        root.next = new ListNode(2);

        var expected = new ListNode(2);
        expected.next = new ListNode(1);

        // Act
        var result = ReverseList(root);

        // Assert
        AssertTwoLinkedListIsEqual(expected, result);
    }

    [Fact]
    public void ReverseListTests3()
    {
        // Arrange
        ListNode root = null;

        // Act
        var result = ReverseList(root);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ReverseListTests4()
    {
        // Arrange
        var root = new ListNode(1);
        var expected = new ListNode(1);

        // Act
        var result = ReverseList(root);

        // Assert
        AssertTwoLinkedListIsEqual(expected, result);
    }

    private void AssertTwoLinkedListIsEqual(ListNode expected, ListNode result)
    {
        while (result != null)
        {
            Assert.Equal(expected.val, result.val);
            result = result.next;
            expected = expected.next;
        }
    }

}
