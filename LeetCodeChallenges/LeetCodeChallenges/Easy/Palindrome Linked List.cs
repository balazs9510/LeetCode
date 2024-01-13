using Xunit;
using LeetCodeChallenges.Utils;

namespace LeetCodeChallenges.Easy;

public class Palindrome_Linked_List
{

    // O(n) time, O(1) space with reversal
    public bool IsPalindrome(ListNode head)
    {
        var fast = head; var slow = head;
        // move slow to middle
        while (fast is not null && fast.next is not null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }
        ListNode prev = null;
        // move slow to end and create a reversed list
        while (slow is not null)
        {
            var temp = slow.next;
            slow.next = prev;
            prev = slow;
            slow = temp;
        }

        fast = head; slow = prev;
        while (slow is not null)
        {
            if (slow.val != fast.val) return false;
            slow = slow.next;
            fast = fast.next;
        }

        return true;
    }


    // O(n) time, O(n) space
    public bool IsPalindromeMyWay(ListNode head)
    {
        var iterator = head;
        var stack = new Stack<int>();
        while (iterator != null)
        {
            stack.Push(iterator.val);
            iterator = iterator.next;
        }
        iterator = head;
        while (iterator != null)
        {
            if (iterator.val != stack.Pop()) return false;
            iterator = iterator.next;
        }
        return true;
    }


    [Fact]
    public void IsPalindromeTest1()
    {
        // Arrange
        var root = new ListNode(1);
        root.next = new ListNode(2);
        root.next.next = new ListNode(2);
        root.next.next.next = new ListNode(1);

        // Act
        var res = IsPalindrome(root);

        // Assert
        Assert.True(res);

    }

    [Fact]
    public void IsPalindromeTest2()
    {
        // Arrange
        var root = new ListNode(1);
        root.next = new ListNode(2);

        // Act
        var res = IsPalindrome(root);

        // Assert
        Assert.False(res);

    }
}
