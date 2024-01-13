using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class ValidParentheses
    {
        private static readonly Dictionary<char, char> MatchingOpeningLookUp = new Dictionary<char, char> { { ')', '(' }, { ']', '[' }, { '}', '{' } };

        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            stack.Push(s[0]);

            for (int i = 1; i < s.Length; i++)
            {
                if (IsOpening(s[i])) stack.Push(s[i]);
                else if (stack.Count > 0 && stack.Peek() == MatchingOpeningLookUp[s[i]]) stack.Pop();
                else return false;
            }

            return stack.Count == 0;
        }

        private bool IsOpening(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }

        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        public void IsValidParenthesesTests(string s, bool expected)
        {
            // Arrange
            // Act
            var result = IsValid(s);

            // Assert
            Assert.Equal(expected, result);
        }

    }
}
