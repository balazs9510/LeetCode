using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Easy
{
    public partial class EasySolution
    {
        public int StrStr(string haystack, string needle)
        {
            if (haystack.Length < needle.Length) return -1;

            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                bool isMatching = true;

                for (int j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j]) { isMatching = false; break; }
                }
                if (isMatching) return i;
            }

            return -1;
        }

        public static void StrStrTests()
        {
            //WriteTestToConsole(0, Instance.StrStr("sadbutsad", "sad"));
            //WriteTestToConsole(-1, Instance.StrStr("leetcode", "leeto"));
            //WriteTestToConsole(-1, Instance.StrStr("a", "ab"));
            //WriteTestToConsole(0, Instance.StrStr("sad", "sad"));
            //WriteTestToConsole(1, Instance.StrStr("asad", "sad"));
        }
    }
}
