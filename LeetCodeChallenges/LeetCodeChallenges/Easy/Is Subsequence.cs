using Xunit;

namespace LeetCodeChallenges.Easy;

public class Is_Subsequence
{
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length > t.Length) return false;
        if (s.Length == t.Length) return s == t;

        int count = 0;

        for (int i = 0; i < t.Length; i++)
        {
            if (s[count] == t[i])
            {
                count++;
                if (count == s.Length) return true;
            }
        }

        return false;
    }


    [Theory]
    [InlineData("abc", "ahbgdc", true)]
    [InlineData("axc", "ahbgdc", false)]
    [InlineData("c", "b", false)]
    [InlineData("bb", "ahbgdc", false)]
    [InlineData("b", "abc", true)]
    [InlineData("abbc", "ahbdc", false)]
    [InlineData("abc", "abc", true)]
    public void IsSubsequenceTests(string s, string t, bool expected)
    {
        // Arrange


        // Act


        // Assert
        Assert.Equal(expected, IsSubsequence(s, t));
    }
}
