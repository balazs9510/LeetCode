using Xunit;

namespace LeetCodeChallenges.Hard
{
    public class Minimum_Insertion_Steps_to_Make_a_String_Palindrome
    {
        public int MinInsertions(string s)
        {
            //int insertionCount = 0, iterator = 0;
            //while (!IsPalindrome(s))
            //{
            //    var length = s.Length - 1;
            //    if (s[iterator] != s[length - iterator])
            //    {
            //        var lastPart = iterator > 0 ? s.Substring(length - iterator + 1, iterator) : string.Empty;
            //        s = s.Substring(0, length - iterator + 1) + s[iterator] + lastPart;
            //        insertionCount++;
            //    }
            //    iterator++;
            //}
            //return insertionCount;

            var dict = new Dictionary<string, int>();
            return 0;
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
        [InlineData("zzazz", 0)]
        //[InlineData("mbadm", 2)]
        //[InlineData("leetcode", 5)]
        //[InlineData("zjveiiwvc", 5)]
        public void MinInsertionsTests(string input, int expectedOutcome)
        {
            // Arrange & Act

            int res = MinInsertions(input);

            // Assert
            Assert.Equal(expectedOutcome, res);
        }
    }
}
