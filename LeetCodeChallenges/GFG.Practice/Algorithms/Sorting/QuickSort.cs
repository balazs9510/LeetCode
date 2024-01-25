namespace GFG.Practice.Algorithms.Sorting;

public class QuickSort : ISorter
{
    public int[] Sort(int[] nums)
    {
        Sort(nums, 0, nums.Length - 1);

        return nums; ;
    }

    private void Sort(int[] nums, int left, int right)
    {
        if (left >= right) return;

        int partionIndex = Partition(nums, left, right);
        Sort(nums, left, partionIndex - 1);
        Sort(nums, partionIndex + 1, right);
    }

    private int Partition(int[] nums, int left, int right)
    {
        int pivot = nums[right];

        var index = left;
        for (int j = left; j < right; j++)
        {
            if (nums[j] < pivot)
            {
                Swap(nums, j, index);
                index++;
            }
        }

        Swap(nums, right, index);
        return index;
    }

    private static void Swap(int[] nums, int first, int second)
    {
        var temp = nums[first];
        nums[first] = nums[second];
        nums[second] = temp;
    }
}
