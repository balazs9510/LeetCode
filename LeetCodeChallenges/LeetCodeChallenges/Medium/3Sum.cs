using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class _3Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var res = new List<IList<int>>();
            var resDistinct = new Dictionary<string, bool>();
            var lookUp = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                var first = nums[i];
                lookUp = new Dictionary<int, int>();
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var current = nums[j];
                    var sum = first + current;
                    var search = 0 - sum;

                    if (lookUp.ContainsKey(search))
                    {
                        var items = new List<int> { first, search, current };
                        items.Sort();
                        var key = string.Join(' ', items); ;
                        if (!resDistinct.ContainsKey(key))
                        {
                            resDistinct.Add(key, true);
                            res.Add(items);
                        }
                    }

                    if (lookUp.ContainsKey(current))
                    {
                        lookUp[current]++;
                    }
                    else
                    {
                        lookUp.Add(current, 1);
                    }

                }
            }

            return res;
        }

        [Theory]
        [InlineData(new int[] { -1, 0, 1, 2, -1, -4 })]
        [InlineData(new int[] { 0, 1, 1 })]
        [InlineData(new int[] { 0, 0, 0 })]
        public void ThreeSumTests(int[] nums)
        {
            // Arrange & act
            var res = ThreeSum(nums);

            // assert
        }
    }
}
