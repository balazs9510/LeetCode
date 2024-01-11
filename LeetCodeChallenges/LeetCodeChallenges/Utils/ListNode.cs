namespace LeetCodeChallenges.Utils
{
    /// <summary>
    /// Common LeetCode LinkedList model
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode CreateOrderedFrom(List<int> values)
        {
            ListNode head = null;
            ListNode iterator = null;

            foreach (int value in values)
            {
                if (head == null)
                {
                    head = new ListNode(value);
                    iterator = head;
                }
                else
                {
                    iterator.next = new ListNode(value);
                    iterator = iterator.next;
                }
            }

            return head;  
        }

        public static ListNode CreateOrderedFrom(params int[] values)
        {
            return CreateOrderedFrom(values.ToList());
        }
    }
}
