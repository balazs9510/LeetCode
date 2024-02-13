namespace GFG.Practice.Algorithms.Sorting;

public class HeapSort : ISorter
{
    public int[] Sort(int[] nums)
    {
        var n = nums.Length;
        for (int i = n / 2 - 1; i >= 0; i--) Heapify(nums, n, i);

        for (int i = n - 1; i > 0; i--)
        {
            Swap(nums, 0, i);

            Heapify(nums, i, 0);
        }

        return nums;
    }

    private void Heapify(int[] nums, int nonSortedEnd, int currentIndex)
    {
        int largest = currentIndex;
        int leftIndex = 2 * currentIndex + 1;
        int rightIndex = 2 * currentIndex + 2;

        if (leftIndex < nonSortedEnd && nums[leftIndex] > nums[largest])
            largest = leftIndex;

        if (rightIndex < nonSortedEnd && nums[rightIndex] > nums[largest])
            largest = rightIndex;

        if (largest != currentIndex)
        {
            Swap(nums, currentIndex, largest);

            Heapify(nums, nonSortedEnd, largest);
        }
    }

    private void Swap(int[] nums, int i, int j)
    {
        var temp = nums[i]; nums[i] = nums[j]; nums[j] = temp;
    }
}
