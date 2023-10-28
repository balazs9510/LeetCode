using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Microsoft
{
    public class Task2
    {
        public int solution(int[] A, int[] B)
        {
            int aL = A.Length, bL = B.Length;
            int minASum = aL, minBSum = bL;
            int maxASum = aL * 6, maxBSum = bL * 6;
            // eg. A = {6} B = {1,1,1,1,1,1,1} 
            if (maxASum < minBSum || maxBSum < minASum) return -1;

            int aSum = A.Sum(), bSum = B.Sum();
            // 6*100_000 + 6*100_000
            int allSum = aSum + bSum;
            var count = new int[allSum + 1];
            var minChanges = int.MaxValue;
            var currentSum = 0;

            foreach (var item in A)
            {
                count[item]++;
            }
            foreach (var item in B)
            {
                count[item]++;
            }
            for (int i = allSum; i >= 0; i--)
            {
                currentSum += count[i];
                minChanges = Math.Min(minChanges, Math.Abs(allSum -2 * currentSum));
            }
            return minChanges;
        }

        [Fact]
        public void Task2Test()
        {
            var A = new int[] { 5 };
            var B = new int[] { 1, 1, 6 };
            var res = solution(A, B);
        }
    }
}
