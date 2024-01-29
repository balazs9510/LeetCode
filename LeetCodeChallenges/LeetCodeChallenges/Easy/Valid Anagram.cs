using Xunit;

namespace LeetCodeChallenges.Easy;

public class Valid_Anagram
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        var span = new int[26].AsSpan();
        for (int i = 0; i < s.Length; i++)
        {
            span[s[i] - 'a']++;
            span[t[i] - 'a']--;
        }

        foreach (var i in span)
        {
            if (i != 0) return false;
        }
        return true;
    }


    [Theory]
    [InlineData("anagram", "nagaram", true)]
    [InlineData("rat", "car", false)]
    [InlineData("bab", "bba", true)]
    public void IsAnagramTests(string s, string t, bool expected)
    {
        // Arrange


        // Act


        // Assert
        Assert.Equal(expected, IsAnagram(s, t));
    }
}
