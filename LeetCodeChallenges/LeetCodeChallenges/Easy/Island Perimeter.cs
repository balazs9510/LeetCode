using Xunit;

namespace LeetCodeChallenges.Easy;

public class Island_Perimeter
{
    private record Point(int x, int y);

    public int IslandPerimeter(int[][] grid)
    {
        int perimeter = 0;
        int rowCount = grid.Length;
        for (int row = 0; row < rowCount; row++)
        {
            int colCount = grid[row].Length;
            for (int col = 0; col < colCount; col++)
            {
                if (grid[row][col] == 1)
                {
                    perimeter += 4;

                    if (col - 1 >= 0 && grid[row][col - 1] == 1) perimeter -= 1; // left is island
                    if (col + 1 < colCount && grid[row][col + 1] == 1) perimeter -= 1; // right is island
                    if (row - 1 >= 0 && grid[row - 1][col] == 1) perimeter -= 1; // top island
                    if (row + 1 < rowCount && grid[row + 1][col] == 1) perimeter -= 1; // bottom island
                }

            }
        }

        return perimeter;
    }

    [Theory]
    [MemberData(nameof(TestDatas))]
    public void IslandPerimeterTests(int[][] grid, int expected)
    {
        Assert.Equal(expected, IslandPerimeter(grid));
    }

    public static IEnumerable<object[]> TestDatas => new List<object[]>
    {
        new object[] {
            new int[][] {
                new int[] {0,1,0,0},
                new int[] {1,1,1,0 },
                new int[] {0,1,0,0 },
                new int[] {1,1,0,0 }
            }, 16
        },
        new object[] {new int[][] {new int[] {1} }, 4 },
        new object[] {new int[][] {new int[] {1,0} }, 4 },
        new object[] {new int[][] {new int[] {0,1} }, 4 }
    };
}
