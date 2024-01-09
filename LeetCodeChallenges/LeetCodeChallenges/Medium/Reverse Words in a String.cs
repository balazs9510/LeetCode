using System.Text;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Reverse_Words_in_a_String
    {
        public string ReverseWords(string s)
        {
            var words = new List<string>();
            var sb = new StringBuilder();

            for (int i = 0; i < s.Length; i++)
            {
                var current = s[i];
                if (current != ' ')
                {
                    sb.Append(current);
                }
                else
                {
                    if (sb.Length > 0)
                    {
                        words.Add(sb.ToString());
                        sb = new StringBuilder();
                    }
                }

            }

            if (sb.Length > 0)
            {
                words.Add(sb.ToString());
            }

            words.Reverse();
            return string.Join(' ', words);

            //List<string> words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            //words.Reverse();

            //return string.Join(' ', words);
        }

        [Theory]
        [InlineData("the sky is blue", "blue is sky the")]
        [InlineData("  hello world  ", "world hello")]
        [InlineData("a good   example", "example good a")]
        public void ReverseWordsTests(string s, string expected)
        {
            // Arrange & act
            var res = ReverseWords(s);

            // Assert
            Assert.Equal(expected, res);
        }
    }
}
