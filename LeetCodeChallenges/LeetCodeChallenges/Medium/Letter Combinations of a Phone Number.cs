using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Letter_Combinations_of_a_Phone_Number
    {
        private readonly Dictionary<char, string> _map = new()
        {
            { '2' , "abc" },
            { '3' , "def" },
            { '4' , "ghi" },
            { '5' , "jkl" },
            { '6' , "mno" },
            { '7' , "pqrs" },
            { '8' , "tuv" },
            { '9' , "wxyz" },
        };


        public IList<string> LetterCombinations(string digits)
        {
            var result = new List<string>();
            if (digits == "") return result;
            LetterCombinationsRec(result, "", digits);
            return result;
        }

        private void LetterCombinationsRec(List<string> results, string current, string digits)
        {
            if (current.Length == digits.Length) { results.Add(current); return; }

            var digit = digits[current.Length];

            foreach (var character in _map[digit])
            {
                LetterCombinationsRec(results, current + character, digits);
            }
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void LetterCombinationsTests(string digits, List<string> expected)
        {
            var result = LetterCombinations(digits);

            Assert.Equal(expected.Count, result.Count);

            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }

        public static IEnumerable<object[]> Data =>
          new List<object[]>
          {
                new object[] { "23", new List<string> { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" } },
                new object[] { "", new List<string>() },
                new object[] { "2", new List<string> { "a", "b", "c" } },
          };
    }
}
