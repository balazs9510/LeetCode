using Xunit;

namespace LeetCodeChallenges.Medium;

public class Longest_Palindromic_Substring
{
    public string LongestPalindrome(string s)
    {
        if (s.Length == 1) return s;
        var max = "";
        for (var i = 0; i < s.Length - 1; i++)
        {
            var left = i;
            var right = i;
            DoSearch(s, ref max, ref left, ref right);

            left = i;
            right = i + 1;
            DoSearch(s, ref max, ref left, ref right);
        }

        return max;
    }

    private static void DoSearch(string s, ref string max, ref int left, ref int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            if ((right - left + 1) > max.Length)
            {
                max = s.Substring(left, right - left + 1);
            }

            left--;
            right++;
        }
    }

    private bool IsPalindrome(string s)
    {
        for (int i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
                return false;
        }

        return true;
    }


    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("cbbd", "bb")]
    [InlineData("a", "a")]
    [InlineData("baaaab", "baaaab")]
    [InlineData("baaaaba", "baaaab")]
    [InlineData("ac", "a")]
    [InlineData("euazbipzncptldueeuechubrcourfpftcebikrxhybkymimgvldiwqvkszfycvqyvtiwfckexmowcxztkfyzqovbtmzpxojfofbvwnncajvrvdbvjhcrameamcfmcoxryjukhpljwszknhiypvyskmsujkuggpztltpgoczafmfelahqwjbhxtjmebnymdyxoeodqmvkxittxjnlltmoobsgzdfhismogqfpfhvqnxeuosjqqalvwhsidgiavcatjjgeztrjuoixxxoznklcxolgpuktirmduxdywwlbikaqkqajzbsjvdgjcnbtfksqhquiwnwflkldgdrqrnwmshdpykicozfowmumzeuznolmgjlltypyufpzjpuvucmesnnrwppheizkapovoloneaxpfinaontwtdqsdvzmqlgkdxlbeguackbdkftzbnynmcejtwudocemcfnuzbttcoew", "aqkqa")]
    public void LongestPalindromeTests(string s, string expected) => Assert.Equal(expected, LongestPalindrome(s));

}
