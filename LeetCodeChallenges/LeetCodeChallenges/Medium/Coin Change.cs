using Xunit;

namespace LeetCodeChallenges.Medium;

public class Coin_Change
{
    public int CoinChange(int[] coins, int amount)
    {
        if (amount == 0) return 0;

        Array.Sort(coins);
        var c = 0;
        foreach (int coin in coins.Reverse())
        {
            while (amount - coin >= 0)
            {
                amount -= coin;
                c++;
            }
        }

        return amount == 0 ? c : -1;
    }


    [Theory]
    [InlineData(new int[] { 1, 2, 5 }, 11, 3)]
    [InlineData(new int[] { 2 }, 3, -1)]
    [InlineData(new int[] { 1 }, 0, 0)]
    [InlineData(new int[] { 186, 419, 83, 408 }, 6249, 20)]
    public void CoinChangeTests(int[] coins, int amount, int expected)
    {
        // Arrange
        // Act
        // Assert
        Assert.Equal(expected, CoinChange(coins, amount));
    }
}
