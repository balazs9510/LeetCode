using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Best_Time_to_Buy_and_Sell_Stock
    {
        public int MaxProfit(int[] prices)
        {
            var min = prices[0];
            var maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                var current = prices[i];

                if (current < min)
                {
                    min = current;
                }
                if (maxProfit < current - min) maxProfit = current - min;
            }
            return maxProfit;
        }
        [Theory]
        [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
        [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
        public void MaxProfitTests(int[] prices, int expected)
        {
            // Arrange & act
            var res = MaxProfit(prices);

            // Assert
            Assert.Equal(expected, res);
        }

    }
}
