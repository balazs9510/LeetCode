using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Make_The_String_Great
{
    public string MakeGood(string s)
    {
        Stack<char> stack = new Stack<char>(s.Length);
        for (int i = 0; i < s.Length; i++)
        {
            if (stack.Count == 0)
            {
                stack.Push(s[i]);
                continue;
            }

            char top = stack.Peek();

            if (Math.Abs(top - s[i]) == 32)
            {
                stack.Pop();
            }
            else
            {
                stack.Push(s[i]);
            }
        }
        string res = "";

        while (stack.Count > 0)
        {
            var curr = stack.Pop();
            res = curr + res;
        }

        return res;
    }


    [Theory]
    [InlineData("leEeetcode", "leetcode")]
    [InlineData("abBAcC", "")]
    [InlineData("BbaaAacc", "aacc")]
    [InlineData("s", "s")]
    public void MakeGoodTests(string text, string expected)
    {
        // Arrange
        // Act
        var res = MakeGood(text);

        // Assert
        Assert.Equal(expected, res);
    }
}
