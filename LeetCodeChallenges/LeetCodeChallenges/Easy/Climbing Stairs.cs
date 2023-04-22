using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace LeetCodeChallenges.Easy
{
    public class Climbing_Stairs
    {

        public int ClimbStairs(int n)
        {
            var memo = new int?[45];
            return ClimbStairsRecursive(n, 0, memo);
        }


        // TODO use memo and stairs left
        private int ClimbStairsRecursive(int stairsLeft, int distinctWayCount, int?[] memo)
        {
            int[] steps = new int[] { 1, 2 };
            foreach (int step in steps)
            {
                if (step > stairsLeft) continue;

                if (memo[stairsLeft - step] != null)
                {
                    distinctWayCount += memo[stairsLeft - step].Value;
                }
                else
                {
                    if (step < stairsLeft)
                    {
                        distinctWayCount = ClimbStairsRecursive(stairsLeft - step, distinctWayCount, memo);
                    }
                    else if (step == stairsLeft)
                    {
                        distinctWayCount++;
                    }
                }

            }
            if (memo[stairsLeft] == null)
                memo[stairsLeft] = distinctWayCount;
            return distinctWayCount;
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(5, 8)]
        [InlineData(44, 1134903170)]
        public void ClimbStairsTests(int input, int expectedOutcome)
        {
            // Arrange & act
            var result = ClimbStairs(input);

            // Assert
            Assert.Equal(expectedOutcome, result);
        }
    }
}
