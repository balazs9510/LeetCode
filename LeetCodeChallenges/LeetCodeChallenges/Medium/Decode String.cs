using System.Text;
using Xunit;

namespace LeetCodeChallenges.Medium;

public class Decode_String
{
    public string DecodeString(string s)
    {
        var builder = new StringBuilder();
        var countBuilder = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (!char.IsDigit(s[i])) builder.Append(s[i]);
            else
            {
                var count = s[i] - '0';
                countBuilder.Append(count);
                i++;
                while (char.IsDigit(s[i]))
                {
                    count = s[i] - '0';
                    countBuilder.Append(count);
                    i++;
                }
                var actualCount = int.Parse(countBuilder.ToString());
                countBuilder.Clear();
                var startIndex = i + 1;
                var endIndex = FindClosingIndex(s, startIndex);
                var decodedString = DecodeString(s.Substring(startIndex, endIndex - startIndex));
                for (int j = 0; j < actualCount; j++)
                {
                    builder.Append(decodedString);
                }
                i = endIndex;
            }
        }

        return builder.ToString();
    }

    private int FindClosingIndex(string s, int startingIndex)
    {
        var stack = new Stack<int>();
        stack.Push(1);
        while (stack.Count > 0)
        {
            if (s[startingIndex] == ']') stack.Pop();
            if (s[startingIndex] == '[') stack.Push(1);
            startingIndex++;
        }

        return startingIndex - 1;
    }

    [Theory]
    [InlineData("3[a]2[bc]", "aaabcbc")]
    [InlineData("3[a2[c]]", "accaccacc")]
    [InlineData("2[abc]3[cd]ef", "abcabccdcdcdef")]
    [InlineData("10[a]", "aaaaaaaaaa")]
    public void DecodeStringTests(string decoded, string expected)
    {
        Assert.Equal(expected, DecodeString(decoded));
    }
}
