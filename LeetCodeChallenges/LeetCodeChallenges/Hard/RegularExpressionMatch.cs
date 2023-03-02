using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Hard
{
    public partial class HardSolution
    {

        public bool IsMatchingRegularExpression(string s, string p)
        {
            if (s.Length == 0 && p.Length == 0) return true;
            if (s.Length == 0 && p.Length != 0) return false;

            var dp = new bool[s.Length + 1, p.Length + 1];

            // match the empty string
            dp[0, 0] = true;
            for (int i = 1; i <= p.Length; i++)
            {
                if (p[i - 1] == '*') dp[0, i] = dp[0, i - 2];
            }

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 2];
                        if (p[j - 2] == '.' || p[j - 2] == s[i - 1])
                        {
                            dp[i, j] = dp[i, j] | dp[i - 1, j];
                        }
                    }
                }
            }

            return dp[s.Length, p.Length];
        }



        public static void IsMatchingRegularExpressionTests()
        {
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("c", "a*b*c"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaabc", "a*b*c"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaabc", "a*ab*c"));
            WriteTestToConsole(false, Instance.IsMatchingRegularExpression("aa", "a*b"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aab", "a*b"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaaaaaaaab", "a*b"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("adsadsadadab", "a.*b"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("ab", "ab*"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("mississippi", "mis*is*ip*."));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("adsadsadadabc", "a.*bc"));
            WriteTestToConsole(false, Instance.IsMatchingRegularExpression("adsadsadadabc", "a.*b"));
            WriteTestToConsole(false, Instance.IsMatchingRegularExpression("cb", "a*b"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("ab", "a.*b"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaa", "a*a"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("b", "a*b"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aab", "a*b"));
            WriteTestToConsole(false, Instance.IsMatchingRegularExpression("aa", "a*b"));
            WriteTestToConsole(false, Instance.IsMatchingRegularExpression("bb", "a*b"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aa", "a*"));
            WriteTestToConsole(false, Instance.IsMatchingRegularExpression("aa", "a"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaba", "aa.a"));
            WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aa", "a."));
            WriteTestToConsole(false, Instance.IsMatchingRegularExpression("aa", "aab"));
        }

    }
}
