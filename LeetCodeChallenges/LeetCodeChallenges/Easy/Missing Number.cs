using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Missing_Number
    {
        public int MissingNumber(int[] nums)
        {
            //if (nums.Length == 1) return nums[0] == 0 ? 1 : 0;

            //int min = nums[0], max = nums[0], sum = 0;

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    var item = nums[i];
            //    if (item < min) min = item;
            //    if (item > max) max = item;
            //    sum += item;
            //}

            //var upper = max * (max + 1) / 2;
            //var lower = (min) * (min + 1) / 2 - min;

            //var res = upper - lower - sum;
            //return res == 0 ? (max == nums.Length ? min - 1 : max + 1) : res;
            var n = nums.Length;
            return n * (n + 1) / 2 - nums.Sum();
        }



        [Theory]
        [InlineData(new[] { 3, 0, 1 }, 2)]
        [InlineData(new[] { 0, 1 }, 2)]
        [InlineData(new[] { 1, 2 }, 0)]
        [InlineData(new[] { 1 }, 0)]
        [InlineData(new[] { 0, 2 }, 1)]
        [InlineData(new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
        //[InlineData(new[] { 4, 6, 7 }, 5)]

        public void MissingNumberTests(int[] n, int expected)
        {
            // Arrange & act
            var res = MissingNumber(n);

            // Assert
            Assert.Equal(expected, res);
        }
    }
}
