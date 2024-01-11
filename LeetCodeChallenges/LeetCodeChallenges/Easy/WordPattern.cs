using Xunit;

namespace LeetCodeChallenges.Easy;

public class WordPattern_
{
    public bool WordPattern(string pattern, string s)
    {
        var subStrings = s.Split(' ');
        if (pattern.Length != subStrings.Length) return false;

        Dictionary<char, string> patterSubStringMap = new Dictionary<char, string>();
        HashSet<string> mappedWords = new HashSet<string>();
        for (int i = 0; i < pattern.Length; i++)
        {
            var currentPatternCharacter = pattern[i];
            var currentSubString = subStrings[i];
            if (patterSubStringMap.ContainsKey(currentPatternCharacter))
            {
                var matchingValue = patterSubStringMap[currentPatternCharacter];
                if (currentSubString != matchingValue) return false;
            }
            else
            {
                if (!mappedWords.Contains(currentSubString))
                {
                    patterSubStringMap.Add(currentPatternCharacter, currentSubString);
                    mappedWords.Add(currentSubString);
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }


    [Theory]
    [InlineData("abba", "dog cat cat dog", true)]
    [InlineData("abba", "dog cat cat fish", false)]
    [InlineData("aaaa", "dog cat cat dog", false)]
    [InlineData("abc", "dog cat fish", true)]
    [InlineData("abc", "dog cat cat", false)]
    [InlineData("abc", "dog cat", false)]
    public void WordPatternTests(string pattern, string text, bool expected)
    {
        // Arrange
        // Act
        var result = WordPattern(pattern, text);

        // Assert
        Assert.Equal(expected, result);
    }
}
