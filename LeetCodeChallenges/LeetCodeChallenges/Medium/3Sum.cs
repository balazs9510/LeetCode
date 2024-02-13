using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class _3Sum
    {

        public IList<IList<int>> ThreeSum(int[] nums) => ThreeSumE(nums).ToList();

        public IEnumerable<IList<int>> ThreeSumE(int[] nums)
        {
            Array.Sort(nums);
            //-1,0,1,2,-1,-4 0
            //-4,-1,-1,0,1,2
            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                if (nums[i] > 0) break;
                int l = i + 1;
                int r = nums.Length - 1;

                while (l < r)
                {
                    var sum = nums[i] + nums[l] + nums[r];
                    if (sum == 0)
                    {
                        yield return new int[] { nums[i], nums[l], nums[r] };
                        l++;
                        while (nums[l] == nums[l - 1] && l < r) { l++; }
                    }
                    else if (sum < 0)
                    {
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
            }
            //return res/*ult;*/
        }

        // Old
        public IList<IList<int>> ThreeSumOld(int[] nums)
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
            var res = ThreeSum(nums).ToList();

            // assert
        }
    }
}
