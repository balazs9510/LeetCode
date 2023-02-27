using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Medium
{
    public partial class MediumSolution
    {
        public string LongestPalindrome(string s)
        {
            return LongestPalindromeRecursive(s, s.Length);
        }

        private string LongestPalindromeRecursive(string s, int length)
        {
            if (length == 0) { return ""; }

            for (int i = 0; i <= s.Length - length; i++)
            {
                string toCheck = s.Substring(i, length);
                if (IsPalindrome(toCheck)) { return toCheck; }
            }
            return LongestPalindromeRecursive(s, length - 1);
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

        public static void LongestPalindromeTest()
        {
            var sol = new MediumSolution();
            Console.WriteLine(sol.LongestPalindrome("babad"));
            Console.WriteLine(sol.LongestPalindrome("cbbd"));
        }

    }
}
