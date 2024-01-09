using System.Text;
using Xunit;

namespace LeetCodeChallenges.Hard
{
    public class Permutation_Sequence
    {
        public string GetPermutation(int n, int k)
        {
            var sb = new StringBuilder();
            var numbers = Enumerable.Range(1, n).ToList();
            var index = 0;
            var l = 0;
            while (sb.Length != n)
            {
                // range (n - index - 1)!
                var fact = Factorial(n - index - 1);

                for (int i = 0; i < numbers.Count; i++)
                {
                    var current = numbers[i];
                    var bottom = fact * i + l;
                    var top = fact * (i + 1) + l;
                    if (k >= bottom && k <= top)
                    {
                        sb.Append(current);
                        l = bottom;
                        index++;
                        numbers.RemoveAt(i);
                        break;
                    }
                }
            }

            return sb.ToString();
        }

        public int Factorial(int n)
        {
            var fact = 1;
            for (var i = 1; i <= n; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        [Theory]
        [InlineData(3, 3, "213")]
        [InlineData(4, 9, "2314")]
        [InlineData(4, 6, "1432")]
        [InlineData(3, 1, "123")]
        [InlineData(9, 362880, "987654321")]
        public void GetPermutationTests(int n, int k, string expected)
        {
            // Arrange & act
            var res = GetPermutation(n, k);

            // Assert
            Assert.Equal(expected, res);
        }
    }
}
