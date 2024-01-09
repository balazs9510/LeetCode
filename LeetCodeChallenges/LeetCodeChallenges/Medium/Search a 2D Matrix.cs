using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Search_a_2D_Matrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            var cols = matrix[0].Length;
            int lR = 0; int rR = matrix.Length - 1;

            while (lR < rR)
            {
                int mR = lR + (rR - lR) / 2;
                var rowItem = matrix[mR][0];
                var topRowItem = matrix[mR][cols - 1];
                if (rowItem == target) return true;
                if (target >= rowItem && topRowItem >= target)
                {
                    lR = mR;
                    break;
                }
                if (rowItem < target) lR = mR + 1;
                else rR = mR - 1;
            }
            if (matrix[lR][cols - 1] < target)
                return false;
            if (matrix[lR][0] > target)
                return false;
            int lC = 0; int rC = cols - 1;
            while (lC < rC)
            {
                int mC = lC + (rC - lC) / 2;
                var rowItem = matrix[lR][mC];
                if (rowItem == target) return true;

                if (rowItem < target) lC = mC + 1;
                else rC = mC - 1;
            }

            return matrix[lR][lC] == target;
        }

        [Fact]
        public void SearchMatrixTest()
        {
            var matrix = new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 60 } };

            var res = SearchMatrix(matrix, 3);

            Assert.True(res);
        }


        [Fact]
        public void SearchMatrixTest2()
        {
            var matrix = new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 60 } };

            var res = SearchMatrix(matrix, 13);

            Assert.False(res);
        }

        [Fact]
        public void SearchMatrixTest3()
        {
            var matrix = new int[][] { new int[] { 1 } };

            var res = SearchMatrix(matrix, 2);

            Assert.False(res);
        }

        [Fact]
        public void SearchMatrixTest4()
        {
            var matrix = new int[][] { new int[] { 1, 1 } };

            var res = SearchMatrix(matrix, 2);

            Assert.False(res);
        }

        [Fact]
        public void SearchMatrixTest5()
        {
            var matrix = new int[][] { new int[] { 2, 3 } };

            var res = SearchMatrix(matrix, 1);

            Assert.False(res);
        }

        [Fact]
        public void SearchMatrixTest6()
        {
            var matrix = new int[][] { new int[] { 1, 3, 5, 7 }, new int[] { 10, 11, 16, 20 }, new int[] { 23, 30, 34, 50 } };

            var res = SearchMatrix(matrix, 20);

            Assert.True(res);
        }
    }
}
