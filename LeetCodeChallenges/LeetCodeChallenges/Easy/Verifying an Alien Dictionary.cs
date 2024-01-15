using Xunit;

namespace LeetCodeChallenges.Easy;

public class Verifying_an_Alien_Dictionary : IComparer<string>
{
    private string _order;

    public int Compare(string? x, string? y)
    {
        int i = 0;
        while (i < x?.Length && i < y?.Length)
        {
            if (x[i] != y[i])
            {
                return _order.IndexOf(x[i]) < _order.IndexOf(y[i]) ? -1 : 1;
            }
            i++;
        }

        return x?.Length == y?.Length ? 0 : (x?.Length < y?.Length ? -1 : 1);
    }

    public bool IsAlienSorted(string[] words, string order)
    {
        _order = order;
        
        for (int i = 0; i < words.Length - 1; i++)
        {
            if (Compare(words[i], words[i + 1]) > 0)
            {
                return false;
            }
        }

        return true;
    }


    [Theory]
    [InlineData(new string[] { "hello", "leetcode" }, "hlabcdefgijkmnopqrstuvwxyz", true)]
    [InlineData(new string[] { "word", "world", "row" }, "worldabcefghijkmnpqstuvxyz", false)]
    [InlineData(new string[] { "apple", "app" }, "abcdefghijklmnopqrstuvwxyz", false)]
    public void IsAlienSortedTests(string[] words, string order, bool expected)
    {
        Assert.Equal(expected, IsAlienSorted(words, order));
    }
}
