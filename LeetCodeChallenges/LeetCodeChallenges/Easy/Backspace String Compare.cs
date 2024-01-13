using Xunit;

namespace LeetCodeChallenges.Easy;

public class Backspace_String_Compare
{
    public bool BackspaceCompare(string s, string t)
    {
        var cleanS = Clean(s);
        var cleanT = Clean(t);

        return string.Equals(cleanS, cleanT);
    }

    private string Clean(string s)
    {
        var stack = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (stack.Count == 0)
            {
                if (s[i] == '#') continue;
                stack.Push(s[i]);
            }
            else if (s[i] == '#')
            {
                stack.Pop();
            }
            else
            {
                stack.Push(s[i]);
            }
        }
        string result = "";
        while (stack.Count > 0)
        {
            result = stack.Pop() + result;
        }
        return result;
    }

    [Theory]
    [InlineData("ab#c", "ab#c", true)]
    [InlineData("ab#c", "ad#c", true)]
    [InlineData("ab##", "c#d#", true)]
    [InlineData("a#c", "b", false)]
    [InlineData("#####b", "b", true)]
    [InlineData("aaa###a", "aaaa###a", false)]
    public void BackspaceCompareTests(string s, string t, bool expected)
    {
        // Arrange
        // Act
        var result = BackspaceCompare(s, t);

        // Assert
        Assert.Equal(expected, result);
    }
}
