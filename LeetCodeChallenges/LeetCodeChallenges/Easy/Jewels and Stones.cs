using Xunit;

namespace LeetCodeChallenges.Easy;

public class Jewels_and_Stones
{
    public int NumJewelsInStones(string jewels, string stones)
    {
        int count = 0;
        foreach (var c in stones)
        {
            //if (jewels.Contains(c)) { count++; }
            if (jewels.IndexOf(c) > -1) { count++; }
        }

        return count;
    }


    [Theory]
    [InlineData("aA", "aAAbbbb", 3)]
    [InlineData("z", "ZZ", 0)]
    public void NumJewelsInStonesTests(string jewels, string stones, int expected)
    {
        // Arrange


        // Act


        // Assert
        Assert.Equal(expected, NumJewelsInStones(jewels, stones));
    }
}
