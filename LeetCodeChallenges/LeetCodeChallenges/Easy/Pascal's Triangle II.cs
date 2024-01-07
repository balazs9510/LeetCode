using Xunit;

namespace LeetCodeChallenges.Easy;

public class Pascal_s_Triangle_II
{
    public IList<int> GetRow(int rowIndex)
    {
        if (rowIndex == 0) return new int[] { 1 };
        var prev = new int[] { 1, 1 };

        for (var i = 1; i <= rowIndex; i++)
        {
            var currentRow = new int[i + 1];
            currentRow[0] = 1;
            currentRow[i] = 1;

            for (int j = 1; j < i; j++)
            {
                currentRow[j] = prev[j - 1] + prev[j];
            }
            prev = currentRow;
        }


        return prev;
    }


    [Theory]
    [MemberData(nameof(Data))]
    public void GetRowTests(int rowIndex, int[] expected)
    {
        // Arrange
        // Act
        var result = GetRow(rowIndex);

        // Assert
        for (int j = 0; j < expected.Length; j++)
        {
            Assert.Equal(expected[j], result[j]);
        }
    }

    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 3, new int[] { 1, 3, 3, 1 }  },
            new object[] { 4, new int[] { 1, 4, 6, 4, 1 }  },
            new object[] { 0, new int[] { 1 }  },
            new object[] { 1, new int[] { 1, 1 }  },
        };
}
