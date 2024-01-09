using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Sqrt_x_
    {
        public static int MySqrt(int x)
        {
            int counter = 0;

            while (x > 0)
            {
                x -= 2 * counter + 1;
                counter++;
            }
            return x == 0 ? counter : counter - 1;
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(15, 3)]
        [InlineData(16, 4)]
        [InlineData(24, 4)]
        [InlineData(130, 11)]
        [InlineData(121, 11)]
        public void MySqrtTests(int x, int expected)
        {
            // Arrance & Act
            var res = MySqrt(x);

            // Assert
            Assert.Equal(expected, res);
        }
    }
}
