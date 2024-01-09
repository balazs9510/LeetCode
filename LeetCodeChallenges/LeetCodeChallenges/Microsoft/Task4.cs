using Xunit;

namespace LeetCodeChallenges.Microsoft
{
    public class Task4
    {
        public int solution(int[][] Board)
        {
            var max = 0;
            for (int i = 0; i < Board.Length; i++)
            {
                for (int j = 0; j < Board[0].Length; j++)
                {
                    // check all neighbors that not visited, pick the max, repeat 
                    var res = GetLongestPathRec(Board, (i, j), new List<(int, int)>());
                    if (res > max) max = res;
                }
            }
            return max;
        }
        int[][] neighsMap = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
        // I'm not to good at recursion
        public int GetLongestPathRec(int[][] Board, (int, int) currentIndex, List<(int, int)> visited)
        {
            if (visited.Count == 4)
            {
                return GetIntValue(Board, visited);
            }

            if (currentIndex.Item1 < 0 || currentIndex.Item1 > Board.Length - 1) return 0;
            if (currentIndex.Item2 < 0 || currentIndex.Item2 > Board[0].Length - 1) return 0;
            if (visited.Contains(currentIndex)) return 0;
            visited.Add(currentIndex);
            var max = 0;
            foreach (var neigh in neighsMap)
            {
                var res = GetLongestPathRec(Board, (currentIndex.Item1 - neigh[0], currentIndex.Item2 - neigh[1]), new List<(int, int)>(visited));
                if (res > max) max = res;
            }
            return max;
        }

        public int GetIntValue(int[][] Board, List<(int, int)> visited)
        {
            var value = 0;
            for (int i = 0; i < visited.Count; i++)
            {
                var c = visited[i];
                value += Board[c.Item1][c.Item2] * (int)Math.Pow(10, 3 - i);
            }
            return value;
        }

        [Fact]
        public void Task4Test1()
        {
            var board = new int[][]
            {
                new int[]{1,1,1 },
                new int[]{1,3,4},
                new int[]{1,4,3 }
            };

            var res = solution(board);
            Assert.Equal(4343, res);
        }
        [Fact]
        public void Task4Test2()
        {
            var board = new int[][]
            {
                new int[]{0,1,5,0,0},
            };

            var res = solution(board);
            Assert.Equal(1500, res);
        }
        [Fact]
        public void Task4Test3()
        {
            var board = new int[][]
            {
                new int[]{9,1,1,0,7},
                new int[]{1,0,2,1,0},
                new int[]{1,9,1,1,0},
            };

            var res = solution(board);
            Assert.Equal(9121, res);
        }
    }
}
