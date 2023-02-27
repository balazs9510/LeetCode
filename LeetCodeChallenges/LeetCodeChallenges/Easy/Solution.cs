using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Easy
{
    public partial class Solution
    {
        public string LongestCommonPrefix(string[] strs)
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


        public static void LongestCommonPrefixTest()
        {
            var sol = new Solution();
            Console.WriteLine(sol.LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));
            Console.WriteLine(sol.LongestCommonPrefix(new string[] { "dog", "racecar", "car" }));
        }
    }
}
