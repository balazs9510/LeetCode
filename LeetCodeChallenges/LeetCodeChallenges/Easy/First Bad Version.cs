using Xunit;

namespace LeetCodeChallenges.Easy;

public class First_Bad_Version
{
    private readonly int _badVersion;

    public First_Bad_Version(int badVersion)
    {
        _badVersion = badVersion;
    }

    public int FirstBadVersion(int n)
    {
        int left = 1; int right = n;

        while (left < right)
        {
            var middle = left + (right - left) / 2;

            if (IsBadVersion(middle))
            {
                right = middle;
            }
            else
            {
                left = middle + 1;
            }
        }

        return right;
    }

    public bool IsBadVersion(int version)
    {
        return _badVersion <= version;
    }
}

public class FirstBadVersionTest
{
    [Theory]
    [InlineData(5, 3)]
    [InlineData(1, 1)]
    [InlineData(int.MaxValue, 500)]
    public void FirstBadVersionTests(int n, int bad)
    {
        // Arrange
        var solution = new First_Bad_Version(bad);

        // Act
        // Assert
        Assert.Equal(bad, solution.FirstBadVersion(n));
    }
}
