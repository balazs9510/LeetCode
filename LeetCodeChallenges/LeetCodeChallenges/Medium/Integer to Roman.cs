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
        public string IntToRoman(int num)
        {
            string retval = "";
            int[] compVals = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] symbol = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            int compare = 0;
            while (num > 0)
            {
                while (num < compVals[compare])
                {
                    compare++;
                    if (compare > compVals.Length)
                        break;
                }
                num -= compVals[compare];
                retval += symbol[compare];

            }
            return retval;
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
