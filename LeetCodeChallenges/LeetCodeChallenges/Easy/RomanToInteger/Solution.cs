using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Easy.RomanToInteger
{
    public class Solution
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
    }
}
