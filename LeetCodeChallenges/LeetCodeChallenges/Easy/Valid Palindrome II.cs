using Xunit;

namespace LeetCodeChallenges.Easy;

public class Valid_Palindrome_II
{
    public bool ValidPalindrome(string s)
    {
        int l = 0; int r = s.Length - 1;
        int leftOut = 0;
        var span = s.AsSpan();
        while (l < r && leftOut < 2)
        {
            if (span[l] != span[r])
            {
                return ValidPalindrome(span, l + 1, r) || ValidPalindrome(span, l, r - 1);
            }
            else
            {
                l++;
                r--;
            }
        }

        return true;
    }


    private bool ValidPalindrome(ReadOnlySpan<char> s, int l, int r)
    {
        while (l < r)
        {
            if (s[l] != s[r])
            {
                return false;
            }
            else
            {
                l++;
                r--;
            }
        }

        return true;
    }

    [Theory]
    [InlineData("aba", true)]
    [InlineData("abca", true)]
    [InlineData("abbca", true)]
    [InlineData("abc", false)]
    [InlineData("aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga", true)]
    [InlineData("aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga", true)]
    public void ValidPalindromeTests(string s, bool expected)
    {
        // Arrange


        // Act


        // Assert
        Assert.Equal(expected, ValidPalindrome(s));
    }
}
