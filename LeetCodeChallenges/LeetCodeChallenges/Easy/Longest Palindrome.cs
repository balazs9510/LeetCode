using Xunit;

namespace LeetCodeChallenges.Easy;

public class Longest_Palindrome
{
    public int LongestPalindrome(string s)
    {
        if (s.Length == 1) return 1;

        var dict = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (dict.ContainsKey(s[i])) dict[s[i]]++;
            else dict.Add(s[i], 1);
        }

        var even = dict.Values.Where(x => x % 2 == 0).Sum();
        var odds = dict.Values.Where(x => x % 2 == 1);
        var odd = odds.Select(x => x - 1).DefaultIfEmpty().Sum();

        return even + (odds.Count() > 0 ? odd + 1 : odd);
    }


    [Theory]
    [InlineData("abccccdd", 7)]
    [InlineData("a", 1)]
    [InlineData("civilwartestingwhetherthatnaptionoranynartionsoconceivedandsodedicatedcanlongendureWeareqmetonagreatbattlefiemldoftzhatwarWehavecometodedicpateaportionofthatfieldasafinalrestingplaceforthosewhoheregavetheirlivesthatthatnationmightliveItisaltogetherfangandproperthatweshoulddothisButinalargersensewecannotdedicatewecannotconsecratewecannothallowthisgroundThebravelmenlivinganddeadwhostruggledherehaveconsecrateditfaraboveourpoorponwertoaddordetractTgheworldadswfilllittlenotlenorlongrememberwhatwesayherebutitcanneverforgetwhattheydidhereItisforusthelivingrathertobededicatedheretotheulnfinishedworkwhichtheywhofoughtherehavethusfarsonoblyadvancedItisratherforustobeherededicatedtothegreattdafskremainingbeforeusthatfromthesehonoreddeadwetakeincreaseddevotiontothatcauseforwhichtheygavethelastpfullmeasureofdevotionthatweherehighlyresolvethatthesedeadshallnothavediedinvainthatthisnationunsderGodshallhaveanewbirthoffreedomandthatgovernmentofthepeoplebythepeopleforthepeopleshallnotperishfromtheearth", 983)]
    public void LongestPalindromeTests(string s, int expected)
    {
        // Arrange
        // Act
        // Assert
        Assert.Equal(expected, LongestPalindrome(s));
    }
}