using Xunit;

namespace LeetCodeChallenges.Easy;

public class Pascal_s_Triangle
{
    public IList<IList<int>> Generate(int numRows)
    {
        var result = new List<IList<int>>
        {
            new List<int> { 1 }
        };

        for (int i = 1; i < numRows; i++)
        {
            var currentRow = new int[i + 1];
            currentRow[0] = 1;
            currentRow[i] = 1;

            for (int j = 1; j < i; j++)
            {
                currentRow[j] = result[i - 1][j - 1] + result[i - 1][j];
            }
            result.Add(currentRow);
        }

        return result;
    }


    [Theory]
    [MemberData(nameof(Data))]
    public void GenerateTests(int numRows, List<int[]> expected)
    {
        // Arrange
        // Act
        var result = Generate(numRows);

        // Assert
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < expected[i].Length; j++)
            {
                Assert.Equal(expected[i][j], result[i][j]);
            }
        }
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 5, new List<int[]> { new int[] { 1 }, new int[] { 1,1 }, new int[] { 1, 2, 1 }, new int[] { 1, 3, 3, 1 }, new int[] { 1, 4, 6, 4, 1 } }  },
            new object[] { 1, new List<int[]> { new int[] { 1 } } }
        };
}
