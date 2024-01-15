using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Shortest_Distance_to_a_Character
{
    public int[] ShortestToChar(string s, char c)
    {
        int[] result = Enumerable.Range(0, s.Length).Select(x => int.MaxValue).ToArray();
        for (int i = 0; i < s.Length; i++)
        {
            var current = s[i];
            if (current == c)
            {
                result[i] = 0;
                int iterator = -1;
                while (i + iterator >= 0 && s[i + iterator] != c)
                {
                    result[i + iterator] = Math.Min(result[i + iterator], Math.Abs(iterator));
                    iterator--;
                }
                iterator = 1;
                while (i + iterator < s.Length && s[i + iterator] != c)
                {
                    result[i + iterator] = Math.Min(result[i + iterator], Math.Abs(iterator));
                    iterator++;
                }
            }
        }

        return result;
    }


    [Theory]
    [InlineData("loveleetcode", 'e', new int[] { 3, 2, 1, 0, 1, 0, 0, 1, 2, 2, 1, 0 })]
    [InlineData("aaab", 'b', new int[] { 3, 2, 1, 0 })]
    public void ShortestToCharTests(string s, char c, int[] expected)
    {
        AssertUtils.AssertTwoListIsEqual(expected.ToList(), ShortestToChar(s, c).ToList());
    }
}
