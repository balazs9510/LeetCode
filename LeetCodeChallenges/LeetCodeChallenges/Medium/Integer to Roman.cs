using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Integer_to_Roman
    {
        private Dictionary<int, string> _map = new Dictionary<int, string>
        {
            { 1000, "M"},
            { 900, "CM"},
            { 500,  "D"},
            { 400,  "CD"},
            { 100,  "C"},
            { 90,  "XC"},
            { 50,   "L"},
            { 40,   "XL"},
            { 10,   "X"},
            { 9,   "IX"},
            { 5,    "V"},
            { 4,    "IV"},
            { 1,    "I"},
        };

        public string IntToRoman(int num)
        {
            var sb = new StringBuilder();

            var thousand = num / 1000;
            if (thousand > 0)
            {
                for (int i = 0; i < thousand; i++)
                {
                    sb.Append(_map[1000]);
                }
                num = num - thousand * 1000;
            }

            num = hack(num, 100, sb);
            num = hack(num, 10, sb);
            num = hack(num, 1, sb);

            return sb.ToString();
        }

      
        private int hack(int num, int ten, StringBuilder sb)
        {
            var hundred = num / ten;
            if (hundred > 0)
            {
                if (hundred == 9 || hundred == 4)
                {
                    sb.Append(_map[hundred * ten]);
                }
                else if (hundred >= 5 && hundred <= 8)
                {
                    sb.Append(_map[5 * ten]);
                    for (int i = 0; i < hundred - 5; i++)
                    {
                        sb.Append(_map[ten]);
                    }
                }
                else
                {
                    for (int i = 0; i < hundred; i++)
                    {
                        sb.Append(_map[ten]);
                    }
                }
                num = num - hundred * ten;
            }
            return num;
        }

        [Theory]
        [InlineData(3, "III")]
        [InlineData(58, "LVIII")]
        [InlineData(1994, "MCMXCIV")]
        [InlineData(1, "I")]
        [InlineData(3999, "MMMCMXCIX")]
        public void IntToRomanTests(int number, string expected)
        {
            // Arrange & act
            var res = IntToRoman(number);

            // Assert
            Assert.Equal(expected, res);
        }


    }
}
