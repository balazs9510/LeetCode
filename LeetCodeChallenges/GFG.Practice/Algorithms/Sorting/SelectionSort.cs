namespace GFG.Practice.Algorithms.Sorting;

public class SelectionSort : ISorter
{
    /// <inheritdoc/>
    public int[] Sort(int[] nums)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            var minIndex = i;
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] < nums[minIndex])
                {
                    minIndex = j;
                }
            }

            var temp = nums[i];
            nums[i] = nums[minIndex];
            nums[minIndex] = temp;
        }

        return nums;
    }
}
