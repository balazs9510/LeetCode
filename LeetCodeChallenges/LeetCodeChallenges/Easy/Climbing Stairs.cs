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
        private readonly ITestOutputHelper output;

        public Climbing_Stairs(ITestOutputHelper output)
        {
            this.output = output;
        }

        public int ClimbStairs(int n)
        {
            return ClimbStairsRecursive(n, 0, 0);
        }

        private int ClimbStairsRecursive(int stairCount, int currentCount, int distinctWayCount)
        {
            int[] steps = new int[] { 1, 2 };
            foreach (int step in steps)
            {
                if (currentCount + step < stairCount)
                {
                    distinctWayCount = ClimbStairsRecursive(stairCount, currentCount + step, distinctWayCount);
                }
                else if (currentCount + step == stairCount)
                {
                    distinctWayCount++;
                }
            }

            return distinctWayCount;
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(5, 8)]
        [InlineData(44, 1000000)]
        public void ClimbStairsTests(int input, int expectedOutcome)
        {
            // Arrange & act
            var result = ClimbStairs(input);

            // Assert
            Assert.Equal(expectedOutcome, result);
        }
    }
}
