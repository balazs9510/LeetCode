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
            if (n <= 3)
                return n;

            int[] trees = new int[n];
            trees[0] = 1;
            trees[1] = 2;

            for (int i = 2; i < trees.Length; i++)
            {
                //current tree, left tree right tree
                trees[i] = trees[i - 1] + trees[i - 2];
            }

            return trees[n - 1];
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
