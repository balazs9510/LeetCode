using Xunit;

namespace LeetCodeChallenges.Easy;

public class Palindrome_Linked_List
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

    // O(n) time, O(n) space
    public bool IsPalindrome(ListNode head)
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
