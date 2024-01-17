using System.Text;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Longest_Common_Prefix
{
    public string LongestCommonPrefix(string[] strs)
    {
        var builder = new StringBuilder();
        //int iterator = 0;
        //bool check = true;
        //while (check)
        //{
        //    for (int i = 0; i < strs.Length; i++)
        //    {
        //        if (strs[i].Length >= iterator)
        //        {
        //            check = false;
        //            break;
        //        }

        //        if (strs[i].Substring(0, iterator + 1) != builder.ToString()) { check = false; break; }
        //    }
        //    builder.Append(strs[0][iterator]);
        //    iterator++;
        //}

        return builder.ToString();
    }

    public string LongestCommonPrefixOld(string[] strs)
    {
        int minLength = strs.Select(str => str.Length).Min();
        string commonPrefix = string.Empty;

        for (int i = 0; i < minLength; i++)
        {
            char current = strs[0][i];
            bool isMatching = true;

            for (int j = 1; j < strs.Length; j++)
            {
                if (strs[j][i] != current)
                {
                    isMatching = false;
                    break;
                }
            }

            if (isMatching)
            {
                commonPrefix += current;
            }
            else
            {
                break;
            }
        }

        return commonPrefix;
    }



    [Theory]
    [InlineData(new string[] { "flower", "flow", "flight" }, "fl")]
    [InlineData(new string[] { "dog", "racecar", "car" }, "")]
    public void LongestCommonPrefixTests(string[] strs, string expected)
    {
        Assert.Equal(expected, LongestCommonPrefix(strs));
    }
}
