namespace GFG.Practice.Algorithms.Sorting;

public class BubbleSort : ISorter
{
    /// <inheritdoc/>
    public int[] Sort(int[] nums)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            bool wasSwap = false;
            for (int j = 0; j < nums.Length - i - 1; j++)
            {
                if (nums[j] < nums[j + 1]) continue;

                var temp = nums[j + 1];
                nums[j + 1] = nums[j];
                nums[j] = temp;
                wasSwap = true;
            }
            if (!wasSwap) break;
        }
        return nums;
    }
}
