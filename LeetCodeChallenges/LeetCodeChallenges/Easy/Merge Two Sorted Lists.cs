using LeetCodeChallenges.Utils;
using Xunit;
namespace LeetCodeChallenges.Easy;
public class Merge_Two_Sorted_Lists
{

    // TODO: Not mine, check it
    //public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    //{
    //    ListNode dummyHead = new ListNode(-1);
    //    // Create a dummy node as the starting point
    //    ListNode current = dummyHead;
    //    // Pointer to keep track of the current node

    //    while (list1 != null && list2 != null)
    //    {
    //        if (list1.val <= list2.val)
    //        {
    //            current.next = list1;
    //            list1 = list1.next;
    //        }
    //        else
    //        {
    //            current.next = list2;
    //            list2 = list2.next;
    //        }
    //        current = current.next;
    //    }

    //    // Attach the remaining nodes if any
    //    if (list1 != null)
    //    {
    //        current.next = list1;
    //    }
    //    else
    //    {
    //        current.next = list2;
    //    }

    //    return dummyHead.next;
    //}

    //TODO: implement recursive version too 
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 is null) return list2;
        if (list2 is null) return list1;
        ListNode newHead = null;
        ListNode result = null;
        while (list1 is not null && list2 is not null)
        {
            if (newHead is null)
            {
                if (list1.val < list2.val)
                {
                    newHead = new ListNode(list1.val);
                    result = newHead;
                    list1 = list1.next;
                }
                else
                {
                    newHead = new ListNode(list2.val);
                    result = newHead;
                    list2 = list2.next;
                }
                continue;
            }
            if (list1.val < list2.val)
            {
                result.next = new ListNode(list1.val);
                result = result.next;

                list1 = list1.next;
            }
            else
            {
                result.next = new ListNode(list2.val);
                result = result.next;

                list2 = list2.next;
            }
        }

        while (list1 is not null)
        {
            result.next = new ListNode(list1.val);
            result = result.next;
            list1 = list1.next;
        }

        while (list2 is not null)
        {
            result.next = new ListNode(list2.val);
            result = result.next;
            list2 = list2.next;
        }

        return newHead;
    }

    [Fact]
    public void MergeTwoListsTest1()
    {
        // Arrange
        var first = ListNode.CreateOrderedFrom(1, 2, 4);
        var second = ListNode.CreateOrderedFrom(1, 3, 4);
        var expected = ListNode.CreateOrderedFrom(1, 1, 2, 3, 4, 4);

        // Act
        var result = MergeTwoLists(first, second);

        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, result);
    }

    [Fact]
    public void MergeTwoListsTest2()
    {
        // Arrange
        var first = ListNode.CreateOrderedFrom();
        var second = ListNode.CreateOrderedFrom();
        var expected = ListNode.CreateOrderedFrom();

        // Act
        var result = MergeTwoLists(first, second);

        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, result);
    }

    [Fact]
    public void MergeTwoListsTest3()
    {
        // Arrange
        var first = ListNode.CreateOrderedFrom();
        var second = ListNode.CreateOrderedFrom(0);
        var expected = ListNode.CreateOrderedFrom(0);

        // Act
        var result = MergeTwoLists(first, second);

        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, result);
    }

    [Fact]
    public void MergeTwoListsTest4()
    {
        // Arrange
        var first = ListNode.CreateOrderedFrom(1);
        var second = ListNode.CreateOrderedFrom(2);
        var expected = ListNode.CreateOrderedFrom(1, 2);

        // Act
        var result = MergeTwoLists(first, second);

        // Assert
        AssertUtils.AssertTwoLinkedListIsEqual(expected, result);
    }
}
