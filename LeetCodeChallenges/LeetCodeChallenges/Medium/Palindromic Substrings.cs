using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Palindromic_Substrings
    {
        public int CountSubstrings(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                count++;
                for (int j = i + 1; j < s.Length; j++)
                {
                    var sub = s.Substring(i, j - i + 1);
                    if (IsPalindrome(sub))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - 1 - i]) return false;
            }

            return true;
        }

        [Theory]
        [InlineData("abc", 3)]
        [InlineData("aaa", 6)]
        [InlineData("bab", 4)]
        public void CountSubstringsTests(string s, int expected)
        {
            // Arrange & act
            var res = CountSubstrings(s);

            // Assert
            Assert.Equal(expected, res);
        }
    }
}
