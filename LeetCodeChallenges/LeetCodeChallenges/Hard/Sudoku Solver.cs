using Xunit;

namespace LeetCodeChallenges.Hard
{
    public class Sudoku_Solver
    {
        public struct Area
        {
            public int RowStart;
            public int ColStart;

            public Area(int rowStart, int colStart)
            {
                RowStart = rowStart;
                ColStart = colStart;
            }

            public bool IsValid(int[][] board)
            {
                int sum = 0;
                for (int i = RowStart; i < RowStart + 3; i++)
                {
                    for (int j = ColStart; j < ColStart + 3; j++)
                    {
                        sum += board[i][j];
                    }
                }
                return sum == Sum;
            }
        }

        public static readonly int Sum = 45;

        public readonly List<Area> Areas = new List<Area>
        {
            new Area(0,0),new Area(0,3),new Area(0,6),
            new Area(3,0),new Area(3,3),new Area(3,6),
            new Area(6,0),new Area(6,3),new Area(6,6)
        };

        public void SolveSudoku(char[][] board)
        {
            var grid = Convert(board);

            var res = BackTrack(grid);

            var newBoard = Convert(res);
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i][j] = newBoard[i][j];
                }
                Console.WriteLine(string.Join('|', board[i]));
            }
        }

        public int[][] BackTrack(int[][] board)
        {
            if (!HasEmptyCell(board))
            {
                return board; // All cells are filled, solution found
            }

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (board[row][col] == 0) // Empty cell found
                    {
                        for (int num = 1; num <= 9; num++)
                        {
                            if (IsValidPlacement(board, row, col, num))
                            {
                                board[row][col] = num; // Place the number

                                if (BackTrack(board) != null) // Recursively solve the updated board
                                {
                                    return board; // Solution found, return the completed board
                                }

                                board[row][col] = 0; // Backtrack: undo the number placement
                            }
                        }

                        return null; // No valid number can be placed, backtrack to previous state
                    }
                }
            }

            return null; // No solution found
        }

        private bool IsValidPlacement(int[][] board, int row, int col, int num)
        {
            // Check if the number already exists in the same row or column
            for (int i = 0; i < 9; i++)
            {
                if (board[row][i] == num || board[i][col] == num)
                {
                    return false; // Invalid placement
                }
            }

            // Check if the number already exists in the same 3x3 sub-grid
            int subGridRowStart = row - (row % 3);
            int subGridColStart = col - (col % 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[subGridRowStart + i][subGridColStart + j] == num)
                    {
                        return false; // Invalid placement
                    }
                }
            }

            return true; // Valid placement
        }
        private bool HasEmptyCell(int[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[i].Any(i => i == 0)) return true;
            }

            return false;
        }

        private int[][] Convert(char[][] board)
        {
            int[][] res = new int[9][];

            for (int i = 0; i < 9; i++)
            {
                res[i] = board[i].Select(x => x == '.' ? 0 : x - '0').ToArray();
            }
            return res;
        }

        private char[][] Convert(int[][] board)
        {
            char[][] res = new char[9][];

            for (int i = 0; i < 9; i++)
            {
                res[i] = board[i].Select(x => x.ToString()[0]).ToArray();
            }
            return res;
        }



        //private bool IsValidSolution(int[][] board)
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
        //        if (board[i].Sum() != Sum) return false;               
        //    }
        //    for (int i = 0; i < 9; i++)
        //    {
        //        if (GetCol(board,i).Sum() != Sum) return false;
        //    }
        //    for (int i = 0; i < 9; i++)
        //    {
        //        if (!Areas[i].IsValid(board)) return false;
        //    }
        //    return true;
        //}

        //private int[] GetCol(int[][] board, int colNum)
        //{
        //    int[] col = new int[9];
        //    for (int i = 0; i < 9; i++)
        //    {
        //        col[colNum] = board[i][colNum];
        //    }
        //    return col;
        //}

        //private int[][] DeepCopy(int[][] board)
        //{
        //    return board.Select(x => x.ToArray()).ToArray();
        //}

        [Fact]
        public void SolveSudokuTest()
        {
            var list = new int[] { 1, 2, 3 };
            var board = new char[][]{
                new char[]{'5', '3', '.',  '.', '7', '.',  '.', '.', '.'},
                new char[]{'6', '.', '.',  '1', '9', '5',  '.', '.', '.'},
                new char[]{'.', '9', '8',  '.', '.', '.',  '.', '6', '.'},

                new char[]{'8', '.', '.',  '.', '6', '.',  '.', '.', '3'},
                new char[]{'4', '.', '.',  '8', '.', '3',  '.', '.', '1'},
                new char[]{'7', '.', '.',  '.', '2', '.',  '.', '.', '6'},

                new char[]{'.', '6', '.',  '.', '.', '.',  '2', '8', '.'},
                new char[]{'.', '.', '.',  '4', '1', '9',  '.', '.', '5'},
                new char[]{'.', '.', '.',  '.', '8', '.',  '.', '7', '9'}};

            SolveSudoku(board);
        }
    }
}
