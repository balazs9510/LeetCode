namespace GFG.Practice.Algorithms.Sorting;

public class InsertionSort : ISorter
{
    /// <inheritdoc/>
    public int[] Sort(int[] nums)
    {
        for (int i = 1; i < nums.Length; i++)
        {
            int current = i;
            while (current > 0 && nums[current] < nums[current - 1])
            {
                var temp = nums[current]; 
                nums[current] = nums[current - 1];
                nums[current - 1] = temp;
                current--;
            }
        }

        return nums;
    }
}
