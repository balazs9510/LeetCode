using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Combination_Sum
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            var res = new List<IList<int>>();
            for (int i = 0; i < candidates.Length; i++)
            {
                CombintaionRec(candidates, target, res, i, new List<int>());

            }

            return res;
        }

        private void CombintaionRec(int[] candidates, int target, List<IList<int>> result, int current, List<int> currentList)
        {
            currentList.Add(candidates[current]);
            var sub = target - candidates[current];
            if (sub == 0)
            {
                result.Add(currentList.ToArray());
            }
            if (sub < 0) return;
            for (int i = current; i < candidates.Length; i++)
            {
                CombintaionRec(candidates, sub, result, i, new List<int>(currentList));
            }
        }

        [Theory]
        [InlineData(new int[] { 2, 3, 6, 7 }, 7)]
        [InlineData(new int[] { 2, 3, 5 }, 8)]
        [InlineData(new int[] { 2 }, 1)]
        public void CombinationSumTests(int[] candidates, int target)
        {
            // Arrange & act
            var res = CombinationSum(candidates, target);

            // Assert
            //Assert.Equal(expected, res);
        }
    }
}
