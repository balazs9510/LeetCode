using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class First_Unique_Character_in_a_String
{
    public int FirstUniqChar(string s)
    {
        var dict = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            var current = s[i];

            if (dict.ContainsKey(current))
            {
                dict[current]++;
            }
            else
            {
               dict.Add(current, 1);
            }
        }

        for (int i = 0; i < s.Length; i++)
        {
            var current = s[i];

            if (dict[current] == 1) return i;
        }

        return -1;
    }

    [Theory]
    [InlineData("leetcode", 0)]
    [InlineData("loveleetcode", 2)]
    [InlineData("aabb", -1)]
    [InlineData("aaaa", -1)]
    [InlineData("aaab", 3)]
    [InlineData("abaa", 1)]
    [InlineData("dbddaadbb", -1)]
    public void FirstUniqCharTests(string text, int expected)
    {
        // Arrange
        // Act
        var result = FirstUniqChar(text);

        // Assert
        Assert.Equal(expected, result);
    }
}
