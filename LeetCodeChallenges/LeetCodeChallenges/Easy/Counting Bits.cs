
using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Counting_Bits
{
    public int[] CountBits(int n)
    {
        if (n == 0) return new int[] { 0 };
        if (n == 1) return new int[] { 0, 1 };
        var result = new int[n + 1];
        result[0] = 0;
        result[1] = 1;
        int next = 2;
        for (int i = 2; i <= n; i++)
        {
            if (next == i)
            {
                result[i] = 1;
                next *= 2;
                continue;
            }

            result[i] = result[i - next / 2] + 1;
        }

        return result;
    }

    [Theory]
    [InlineData(2, new int[] { 0, 1, 1 })]
    [InlineData(5, new int[] { 0, 1, 1, 2, 1, 2 })]
    public void CountBitsTests(int n, int[] expected)
    {
        AssertUtils.AssertTwoListIsEqual(expected.ToList(), CountBits(n).ToList());
    }
}
