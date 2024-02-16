using Xunit;

namespace LeetCodeChallenges.Easy;

public class Min_Cost_Climbing_Stairs
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var dp = new int[cost.Length + 1];

        for (var i = 2; i <= cost.Length; i++)
        {
            dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
        }

        return dp[cost.Length];
    }


    [Theory]
    [InlineData(new int[] { 10, 15, 20 }, 15)]
    [InlineData(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
    public void MinCostClimbingStairsTests(int[] cost, int expected) => Assert.Equal(expected, MinCostClimbingStairs(cost));
}
