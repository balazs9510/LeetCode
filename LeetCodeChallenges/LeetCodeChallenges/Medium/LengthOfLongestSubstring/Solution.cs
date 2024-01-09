namespace LeetCodeChallenges.Medium.LengthOfLongestSubstring
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var maxLength = 0;
            var result = "";
            for (int i = 0; i < s.Length; i++)
            {
                var current = s[i];
                if (!result.Contains(current))
                {
                    result += current;
                }
                else
                {
                    if (result.Length > maxLength) maxLength = result.Length;
                    // remove the chars until repeated one
                    result = result.Remove(0, result.IndexOf(current) + 1) + current;
                }
            }
            if (result.Length > maxLength) maxLength = result.Length;

            return maxLength;
        }
    }
}
