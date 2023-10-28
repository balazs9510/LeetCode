using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Unique_Paths
    {
        public int UniquePaths(int m, int n)
        {
            var dp = new int[m][];

            dp[0] = Enumerable.Repeat(1, n).ToArray();
            for (int i = 1; i < m; i++)
            {
                dp[i] = new int[n];
                dp[i][0] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                }
            }

            return dp[m - 1][n - 1];
        }

        [Theory]
        [InlineData(3, 7, 28)]
        [InlineData(3, 2, 3)]
        public void UniquePathsTest(int m, int n, int expected)
        {
            var res = UniquePaths(m, n);

            Assert.Equal(expected, res);
        }
    }
}
