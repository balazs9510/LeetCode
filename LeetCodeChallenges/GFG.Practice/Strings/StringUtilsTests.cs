using Xunit;

namespace GFG.Practice.Strings;

public class StringUtilsTests
{

    [Theory]
    [InlineData("alma", "amla")]
    [InlineData("a", "a")]
    [InlineData("abba", "abba")]
    [InlineData("xyxy", "yxyx")]
    public void ReverseTests(string original, string expected)
    {
        // Arrange
        // Act
        var result = StringUtils.Reverse(original);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("alma", "amla")]
    [InlineData("a", "a")]
    [InlineData("abba", "abba")]
    [InlineData("xyxy", "yxyx")]
    public void ReverseTwoPointersTests(string original, string expected)
    {
        // Arrange
        // Act
        var result = StringUtils.ReverseTwoPointer(original);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("alma", "amla")]
    [InlineData("a", "a")]
    [InlineData("abba", "abba")]
    [InlineData("xyxy", "yxyx")]
    public void ReverseRecursiveTests(string original, string expected)
    {
        // Arrange
        // Act
        var result = StringUtils.ReverseRecursive(original);

        // Assert
        Assert.Equal(expected, result);
    }
}
