using Xunit;

namespace LeetCodeChallenges.Easy;

public class Fibonacci_Number
{
    private int[] _dp = new int[31];

    public int Fib(int n)
    {
        if (n == 0) return 0;
        _dp[0] = 0;
        _dp[1] = 1;

        if (_dp[n] != 0) return _dp[n];
        for (int i = 2; i <= n; i++)
        {
            _dp[i] = _dp[i - 1] + _dp[i - 2];
        }
        return _dp[n];
    }



    [Theory]
    [InlineData(0, 0)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(30, 832040)]
    public void FibTests(int n, int expected) => Assert.Equal(expected, Fib(n));
}
