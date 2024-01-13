using Xunit;

namespace LeetCodeChallenges.Easy;

public class Reverse_String
{
    public void ReverseString(char[] s)
    {
        Array.Reverse(s);
        int l = 0; int r = s.Length - 1;
        while (l < r)
        {
            char temp = s[l];
            s[l] = s[r];
            s[r] = temp;
            l++; r--;
        }
    }

    public void ReverseRecursive(char[] s)
    {
        ReverseRecursiveStep(s, 0, s.Length - 1);
    }

    private void ReverseRecursiveStep(char[] s, int l, int r)
    {
        if (l >= r) return;

        char temp = s[l];
        s[l] = s[r];
        s[r] = temp;

        ReverseRecursiveStep(s, ++l, --r);
    }

    [Theory]
    [InlineData("hello", "olleh")]
    [InlineData("Hannah", "hannaH")]
    public void ReverseStringTests(string start, string expected)
    {
        // Arrange
        var startArray = start.ToArray();
        var expectedArray = expected.ToArray();

        // Act
        ReverseRecursive(startArray);

        // Assert
        for (int i = 0; i < startArray.Length; i++)
        {
            Assert.Equal(expectedArray[i], startArray[i]);
        }
    }
}
