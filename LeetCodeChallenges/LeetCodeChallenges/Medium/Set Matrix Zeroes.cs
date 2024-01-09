using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Set_Matrix_Zeroes
    {
        public void SetZeroes(int[][] matrix)
        {
            var zeroRows = Enumerable.Range(0, matrix.GetLength(0)).ToDictionary(x => x, y => false);
            var zeroCols = Enumerable.Range(0, matrix[0].Length).ToDictionary(x => x, y => false);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        zeroRows[i] = true;
                        zeroCols[j] = true;
                    }
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (zeroRows[i] || zeroCols[j])
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }



        //[Theory]
        //[InlineData()]

        [Fact]
        public void SetZeroesTests()
        {
            // var matrix = new[] { new[] { 1, 1, 1 }, new[] { 1, 0, 1 }, new[] { 1, 1, 1 } };
            var matrix = new[] { new[] { 1, -1000000, 1 }, new[] { 2, 1, 2 } };
            // Arrange & act
            SetZeroes(matrix);

            // Assert
            // Assert.Equal(expected, res);
        }
    }
}
