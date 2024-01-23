namespace GFG.Practice.Algorithms.Sorting;

public class MergeSort : ISorter
{
    /// <inheritdoc/>
    public int[] Sort(int[] nums)
    {
        return DivideAndMerge(nums, 0, nums.Length - 1);
    }

    private int[] DivideAndMerge(int[] nums, int left, int right)
    {
        if (left >= right) return new int[] { nums[left] };

        var middle = left + (right - left) / 2;
        var leftSortedSubArray = DivideAndMerge(nums, left, middle);
        var rightSortedSubArray = DivideAndMerge(nums, middle + 1, right);

        int leftIterator = 0; int rightIterator = 0;
        var res = new int[leftSortedSubArray.Length + rightSortedSubArray.Length];
        while (leftIterator < leftSortedSubArray.Length || rightIterator < rightSortedSubArray.Length)
        {
            if (leftIterator == leftSortedSubArray.Length)
            {
                res[rightIterator + leftIterator] = rightSortedSubArray[rightIterator++];
                continue;
            }
            if (rightIterator == rightSortedSubArray.Length)
            {
                res[rightIterator + leftIterator] = leftSortedSubArray[leftIterator++];
                continue;
            }

            if (leftSortedSubArray[leftIterator] < rightSortedSubArray[rightIterator])
            {
                res[rightIterator + leftIterator] = leftSortedSubArray[leftIterator++];
            }
            else
            {
                res[rightIterator + leftIterator] = rightSortedSubArray[rightIterator++];
            }
        }

        return res;
    }
}
