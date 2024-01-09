using System.Text;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Reverse_Integer
    {
        public int Reverse(int x)
        {
            if (x == 0) return 0;
            string xStirng = Math.Abs((long)x).ToString();
            StringBuilder reverse = new StringBuilder();
            if (x < 0)
                reverse.Append("-");
            for (int i = xStirng.Length - 1; i >= 0; i--)
            {
                reverse.Append(xStirng[i]);
            }

            long res = Convert.ToInt64(reverse.ToString());
            if (int.MinValue <= res && res <= int.MaxValue)
            {
                return (int)res;
            }
            return 0;
        }

        [Theory]
        [InlineData(321, 123)]
        [InlineData(-321, -123)]
        [InlineData(21, 120)]
        [InlineData(21, 1200)]
        [InlineData(10021, 120010)]
        [InlineData(10021, 12001000)]
        [InlineData(0, 0)]
        [InlineData(0, 1534236469)]
        [InlineData(0, int.MinValue)]
        public void ReverseTests(int expected, int input)
        {
            // Arrange & Act

            int res = Reverse(input);

            // Assert
            Assert.Equal(expected, res);
        }
    }
}
