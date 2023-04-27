using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Bulb_Switcher
    {
        public int BulbSwitch(int n)
        {
            return (int)Math.Sqrt(n);
        }



        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 1)]
        [InlineData(1, 1)]
        [InlineData(6, 2)]
        [InlineData(1000000000, 31622)]
        public void BulbSwitchTests(int n, int expected)
        {
            // Arrange & act
            var res = BulbSwitch(n);

            // Assert
            Assert.Equal(expected, res);
        }

    }
}
