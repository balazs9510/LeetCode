using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Middle_of_the_Linked_List
{

    public ListNode MiddleNode(ListNode head)
    {
        var fast = head;
        var slow = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }


    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 4, 5, 6 })]
    public void MiddleNodeTests(int[] nodes, int[] expectedNodes)
    {
        // Arrange
        var head = ListNode.CreateOrderedFrom(nodes);
        var expected = ListNode.CreateOrderedFrom(expectedNodes);

        // Act
        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, MiddleNode(head));
    }
}
