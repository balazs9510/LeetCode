namespace LeetCodeChallenges.Easy
{
    public partial class Solution
    {
        public int MaxProductDifference(int[] nums)
        {
            Array.Sort(nums);

            return nums[nums.Length - 1] * nums[nums.Length - 2] - nums[1] * nums[0];
        }

    }
}
