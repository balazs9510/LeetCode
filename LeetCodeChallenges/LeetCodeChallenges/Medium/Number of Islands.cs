using Xunit;

namespace LeetCodeChallenges.Medium;

public class Number_of_Islands
{
    public int NumIslands(char[][] grid)
    {
        var visited = new bool[grid.Length][];
        for (int i = 0; i < grid.Length; i++)
        {
            visited[i] = new bool[grid[i].Length];
        }

        int islandCount = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if (visited[i][j]) { continue; }


                if (grid[i][j] == '0') { visited[i][j] = true; continue; }

                islandCount++;
                var queue = new Queue<(int, int)>();
                queue.Enqueue((i, j));
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    if (current.Item1 < 0 || current.Item1 >= grid.Length || current.Item2 < 0 || current.Item2 >= grid[0].Length) continue;
                    if (visited[current.Item1][current.Item2]) continue;
                    visited[current.Item1][current.Item2] = true;
                    if (grid[current.Item1][current.Item2] == '0') continue;
                    queue.Enqueue((current.Item1 - 1, current.Item2));
                    queue.Enqueue((current.Item1 + 1, current.Item2));
                    queue.Enqueue((current.Item1, current.Item2 - 1));
                    queue.Enqueue((current.Item1, current.Item2 + 1));
                }
            }
        }

        return islandCount;
    }


    [Fact]
    public void NumIslandstTest1()
    {
        // Arrange
        var grid = new char[][] {
           new char[] {'1', '1', '1', '1', '0'},
           new char[] {'1', '1', '0', '1', '0'},
           new char[] {'1', '1', '0', '0', '0'},
           new char[] {'0', '0', '0', '0', '0'}
        };

        // Act


        // Assert
        Assert.Equal(1, NumIslands(grid));
    }

    [Fact]
    public void NumIslandstTest2()
    {
        // Arrange
        var grid = new char[][] {
           new char[] {'1', '1', '0', '0', '0'},
           new char[] {'1', '1', '0', '0', '0'},
           new char[] {'0', '0', '1', '0', '0'},
           new char[] {'0', '0', '0', '1', '1'}
        };

        // Act


        // Assert
        Assert.Equal(3, NumIslands(grid));
    }
}
