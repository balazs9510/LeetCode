using Xunit;

namespace LeetCodeChallenges.Easy;

public class Roman_to_Integer
{
    Dictionary<char, int> Map = new Dictionary<char, int>
        {
            { 'I', 1},
            { 'V', 5},
            { 'X', 10},
            { 'L', 50},
            { 'C', 100},
            { 'D', 500},
            { 'M', 1000},
        };

    public int RomanToInt(string s)
    {
        var result = 0;

        for (int i = 0; i < s.Length - 1; i++)
        {
            var current = Map[s[i]];

            if (current < Map[s[i + 1]])
            {
                result -= current;
            }
            else
            {
                result += current;
            }

        }
        result += Map[s[s.Length - 1]];
        return result;
    }


    [Theory]
    [InlineData("III", 3)]
    [InlineData("LVIII", 58)]
    [InlineData("MCMXCIV", 1994)]
    public void RomanToIntTests(string s, int expected)
    {
        Assert.Equal(expected, RomanToInt(s));
    }
}
