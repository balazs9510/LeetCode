using Xunit;

namespace LeetCodeChallenges.Easy;

public class Count_Binary_Substrings
{
    public int CountBinarySubstrings(string s)
    {
        if (s.Length < 2) return 0;
        int sum = 0;
        for (int i = 1; i < s.Length; i++)
        {
            int leftIdx = i - 1;
            int rightIdx = i;
            char left = s[leftIdx];
            char right = s[rightIdx];

            while (leftIdx >= 0 && rightIdx < s.Length && left == s[leftIdx] && right == s[rightIdx] && left != right)
            {
                sum++;
                leftIdx--;
                rightIdx++;
            }
        }
        return sum;
    }


    [Theory]
    [InlineData("00110011", 6)]
    [InlineData("10101", 4)]
    [InlineData("000111", 3)]
    public void CountBinarySubstringsTests(string binaryString, int expected)
    {
        // Arrange
        // Act
        var result = CountBinarySubstrings(binaryString);

        // Assert
        Assert.Equal(expected, result);
    }
}
