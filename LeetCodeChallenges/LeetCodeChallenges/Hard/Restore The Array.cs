using Xunit;
using Xunit.Abstractions;

namespace LeetCodeChallenges.Hard
{
    public class Restore_The_Array
    {

        ITestOutputHelper output;

        public Restore_The_Array(ITestOutputHelper testOutput)
        {
            output = testOutput;
        }

        public int NumberOfArrays(string s, int k)
        {
            int mod = (int)1e9 + 7;

            if (s == null || s.Length == 0) return 0;
            int n = s.Length;
            int[] dp = new int[n + 1];
            dp[n] = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                long num = s[i] - '0';
                if (num != 0)
                {
                    for (int j = i + 1; j <= n; j++)
                    {
                        if (num > k) break;
                        dp[i] = (dp[i] + dp[j]) % mod;
                        if (j < n)
                        {
                            num = num * 10 + s[j] - '0';
                        }
                    }
                }
                else
                {
                    dp[i] = 0;
                }
            }

            return dp[0];

        }


        [Theory]
        [InlineData("1000", 10000, 1)]
        [InlineData("1000", 10, 0)]
        [InlineData("1317", 2000, 8)]
        [InlineData("512", 2000, 4)]
        public void MinInsertionsTests(string input, int k, int expectedOutcome)
        {
            // Arrange & Act

            int res = NumberOfArrays(input, k);

            // Assert
            Assert.Equal(expectedOutcome, res);
        }

    }

}