using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Linked_List_Cycle
{
    public bool HasCycle(ListNode head)
    {
        if (head is null) return false;
        var fast = head?.next?.next; var slow = head;
        while (fast != null && slow != null)
        {
            if (fast == slow) return true;
            fast = fast.next?.next;
            slow = slow.next;
        }
        return fast == slow;
    }


	[Fact]
	public void HasCycleTest1()
	{
		// Arrange
		var root = ListNode.CreateOrderedFrom(3, 2, 0, 4);
		//3   2    0   4    
		root.next.next.next.next = root.next;

		// Act
		// Assert
		Assert.True(HasCycle(root));
	}


    [Fact]
    public void HasCycleTest2()
    {
        // Arrange
        var root = ListNode.CreateOrderedFrom(1,2);   
        root.next = root;

        // Act
        // Assert
        Assert.True(HasCycle(root));
    }

    [Fact]
    public void HasCycleTest3()
    {
        // Arrange
        var root = ListNode.CreateOrderedFrom(1);

        // Act
        // Assert
        Assert.False(HasCycle(root));
    }
}
