using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Unique_Paths_II
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var rowC = obstacleGrid.GetLength(0);
            var colC = obstacleGrid[0].Length;

            var dp = new int[rowC, colC];

            dp[0, 0] = obstacleGrid[0][0] == 1 ? 0 : 1;
            for (int i = 1; i < colC; i++)
            {
                if (dp[0, i - 1] == 0 || obstacleGrid[0][i] == 1)
                    dp[0, i] = 0;
                else
                    dp[0, i] = 1;
            }

            for (int i = 1; i < rowC; i++)
            {
                if (dp[i - 1, 0] == 0 || obstacleGrid[i][0] == 1)
                    dp[i, 0] = 0;
                else
                    dp[i, 0] = 1;
            }

            for (int i = 1; i < rowC; i++)
            {
                for (int j = 1; j < colC; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                        dp[i, j] = 0;
                    else
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }

            return dp[rowC - 1, colC - 1];
        }

        [Fact]
        public void UniquePathsWithObstaclesTests()
        {
            //var grid = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 0 } };
            var grid = new int[][] { new int[] { 0, 1 }, new int[] { 0, 0 } };
            // Arrange & act
            var res = UniquePathsWithObstacles(grid);

            // Assert
            // Assert.Equal(2, res);
            Assert.Equal(1, res);
        }
    }
}
