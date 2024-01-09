using Xunit;

namespace LeetCodeChallenges.Easy
{
    public partial class EasySolution
    {
        public int LengthOfLastWord(string s)
        {
            var split = s.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return split.Length > 0 ? split.Last().Length : 0;
        }

        [Theory]
        [InlineData("Hello World", 5)]
        [InlineData(" ", 0)]
        [InlineData("   fly me   to   the moon  ", 4)]
        [InlineData("luffy is still joyboy", 6)]
        public void LengthOfLastWordTests(string input, int expected)
        {
            // Arrange    
            // Act
            int res = LengthOfLastWord(input);
            // Assert
            Assert.Equal(expected, res);
        }
    }
}
