using System.Text;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Remove_All_Adjacent_Duplicates_In_String
{
    #region Stack solution
    public string RemoveDuplicatesStack(string s)
    {
        Stack<char> uniques = new Stack<char>();
        for (int i = 0; i < s.Length; i++)
        {
            char current = s[i];
            bool notInStack = uniques.Count == 0 || current != uniques.Peek();
            if (notInStack)
            {
                uniques.Push(current);
            }
            else
            {
                uniques.Pop();
            }
        }

        string res = "";
        while (uniques.Count > 0)
        {
            res = uniques.Pop() + res;
        }
        return res;
    }
    #endregion

    #region StringBuilder
    public string RemoveDuplicates(string s)
    {
        var builder = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            char current = s[i];
            bool notInString = builder.Length == 0 || current != builder[builder.Length - 1];
            if (notInString)
            {
                builder.Append(current);
            }
            else
            {
                builder.Remove(builder.Length - 1, 1);
            }
        }

        return builder.ToString();
    }
    #endregion

    [Theory]
    [InlineData("abbaca", "ca")]
    [InlineData("azxxzy", "ay")]
    public void RemoveDuplicatesTests(string text, string expected)
    {
        // Arrange
        // Act
        var result = RemoveDuplicates(text);

        // Assert
        Assert.Equal(expected, result);
    }

}
