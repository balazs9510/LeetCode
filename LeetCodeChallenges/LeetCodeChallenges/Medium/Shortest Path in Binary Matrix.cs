using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Shortest_Path_in_Binary_Matrix
    {
        private static int Size = 0;

        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            if (grid[0][0] == 1) return -1;
            Size = grid.Length;
            var visited = new Dictionary<int, bool>();
            var dist = new int[Size * Size];

            var queue = new Queue<int>();
            queue.Enqueue(0);
            dist[0] = 1;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                visited[current] = true;

                var abs = FromAbsIndex(current);
                var neighs = GetNeighs(abs.Item1, abs.Item2);
                foreach (var neighPos in neighs)
                {
                    if (!visited.ContainsKey(neighPos))
                    {
                        visited.Add(neighPos, true);
                        var pos = FromAbsIndex(neighPos);
                        if (grid[pos.Item1][pos.Item2] == 1) continue;

                        queue.Enqueue(neighPos);
                        dist[neighPos] = dist[current] + 1;
                    }
                }
            }

            var last = dist.Last();
            return last == 0 ? -1 : last;
        }

        private List<int> GetNeighs(int x, int y)
        {
            var neighs = new List<int>();
            // everything above
            if (x - 1 >= 0)
            {
                // Top left
                if (y - 1 >= 0) { neighs.Add(ToAbsIndex(x - 1, y - 1)); }
                // Top middle
                neighs.Add(ToAbsIndex(x - 1, y));
                // Top right
                if (y + 1 < Size) { neighs.Add(ToAbsIndex(x - 1, y + 1)); }
            }

            // direct left & right
            if (y - 1 >= 0) { neighs.Add(ToAbsIndex(x, y - 1)); }
            if (y + 1 < Size) { neighs.Add(ToAbsIndex(x, y + 1)); }

            // everything below
            if (x + 1 < Size)
            {
                // bottom left
                if (y - 1 >= 0) { neighs.Add(ToAbsIndex(x + 1, y - 1)); }
                // bottom middle
                neighs.Add(ToAbsIndex(x + 1, y));
                // bottom right
                if (y + 1 < Size) { neighs.Add(ToAbsIndex(x + 1, y + 1)); }
            }

            return neighs;
        }

        private int ToAbsIndex(int x, int y)
        {
            return Size * x + y;
        }

        private (int, int) FromAbsIndex(int index)
        {
            return (index / Size, index % Size);
        }

        [Fact]
        public void ShortestPathBinaryMatrixTest()
        {
            var grid = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 } };

            var res = ShortestPathBinaryMatrix(grid);

            Assert.Equal(2, res);
        }

        [Fact]
        public void ShortestPathBinaryMatrixTest2()
        {
            var grid = new int[][] { new int[] { 0, 0, 0 }, new int[] { 1, 1, 0 }, new int[] { 1, 1, 0 } };

            var res = ShortestPathBinaryMatrix(grid);

            Assert.Equal(4, res);
        }

        [Fact]
        public void ShortestPathBinaryMatrixTest3()
        {
            var grid = new int[][] { new int[] { 1, 0, 0 }, new int[] { 1, 1, 0 }, new int[] { 1, 1, 0 } };

            var res = ShortestPathBinaryMatrix(grid);

            Assert.Equal(-1, res);
        }

        [Fact]
        public void ShortestPathBinaryMatrixTest4()
        {
            var grid = new int[][] {
                new int[] {0, 1, 1, 0, 0, 0},
                new int[] {0, 1, 0, 1, 1, 0},
                new int[] {0, 1, 1, 0, 1, 0},
                new int[] {0, 0, 0, 1, 1, 0},
                new int[] {1, 1, 1, 1, 1, 0},
                new int[] {1, 1, 1, 1, 1, 0} };

            var res = ShortestPathBinaryMatrix(grid);

            Assert.Equal(14, res);
        }
    }
}