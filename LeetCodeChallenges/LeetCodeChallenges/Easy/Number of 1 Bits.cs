using Xunit;

namespace LeetCodeChallenges.Easy;

public class Number_of_1_Bits
{
    public int HammingWeight(uint n)
    {
        uint c = 0;
        while (n != 0)
        {
            c = c + (n & 1);
            n >>= 1;
        }

        return (int)c;
    }

    [Theory]
    [InlineData(0b00000000000000000000000000001011, 3)]
    [InlineData(0b00000000000000000000000010000000, 1)]
    [InlineData(0b11111111111111111111111111111101, 31)]
    public void HammingWeightTests(uint n, int expected) => Assert.Equal(expected, HammingWeight(n));
}
