using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Plus_One
    {
        public int[] PlusOne(int[] digits)
        {
            var res = new Stack<int>();
            bool toIncrement = true;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                var current = digits[i];
                if (toIncrement)
                {
                    current++;
                    if (current > 9)
                    {
                        toIncrement = true;
                        current = 0;
                    }
                    else { toIncrement = false; }
                }
                res.Push(current);
            }
            if (toIncrement) res.Push(1);

            return res.ToArray();
        }


        [Theory]
        [InlineData(new int[] { 1, 2, 4 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 4, 3, 2, 2 }, new int[] { 4, 3, 2, 1 })]
        [InlineData(new int[] { 1, 0 }, new int[] { 9 })]
        [InlineData(new int[] { 1, 0, 0, 0 }, new int[] { 9, 9, 9 })]
        public void PlusOneTests(int[] expected, int[] digits)
        {
            // Arrance & Act
            var res = PlusOne(digits);

            // Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], res[i]);
            }
        }
    }
}
