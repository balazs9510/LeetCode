using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Add_Digits
    {
        public int AddDigits(int num)
        {
            if (num < 10) return num;

            return AddDigits(num.ToString().Select(x => x - '0').Sum());
        }

        [Theory]
        [InlineData(38, 2)]
        [InlineData(0, 0)]
        [InlineData(32, 5)]
        [InlineData(int.MaxValue, 1)]
        [InlineData(999, 9)]
        public void AddDigitsTests(int num, int expected)
        {
            var res = AddDigits(num);

            Assert.Equal(expected, res);
        }
    }
}
