using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class String_to_Integer__atoi_
    {
        public int MyAtoi(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            bool isNegative = false;
            s = s.Trim();
            if (s.StartsWith("-"))
            {
                isNegative = true;
                s = s.Substring(1);
            }
            else if (s.StartsWith("+"))
            {
                s = s.Substring(1);
            }
            if (string.IsNullOrEmpty(s)) return 0;

            int iterator = 0;
            char digit = s[iterator];
            StringBuilder sb = new StringBuilder(digit);
            while (char.IsDigit(digit) && iterator < s.Length)
            {
                iterator++;
                sb.Append(digit);
                if (iterator >= s.Length) break;
                digit = s[iterator];
            }
            
            var stringResult = sb.ToString().TrimStart('0');
            if (stringResult.Length > 10)
            {
               return isNegative ? int.MinValue : int.MaxValue;
            }
            if (iterator == 0 || stringResult.Length == 0) return 0;
            long result = long.Parse(stringResult);
            if (isNegative) { result *= -1L; }

            return (int)Math.Clamp(result, int.MinValue, int.MaxValue);
        }

        [Theory]
        [InlineData("42", 42)]
        [InlineData("+-12", 0)]
        [InlineData("+", 0)]
        [InlineData("0032", 32)]
        [InlineData("  -42", -42)]
        [InlineData("4193 with words", 4193)]
        [InlineData("words and 987", 0)]
        [InlineData("2147483650", int.MaxValue)]
        [InlineData("-3147483650", int.MinValue)]
        [InlineData("20000000000000000000", int.MaxValue)]
        [InlineData("  0000000000012345678", 12345678)]
        [InlineData("00000-42a1234", 0)]
        public void MyAtoiTests(string input, int expectedOutcome)
        {
            // Arrange & act
            var result = MyAtoi(input);

            // Assert
            Assert.Equal(expectedOutcome, result);
        }
    }
}
