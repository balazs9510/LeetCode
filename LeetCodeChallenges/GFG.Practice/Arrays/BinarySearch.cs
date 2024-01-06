using Xunit;

namespace GFG.Practice.Arrays
{
    public class BinarySearch
    {
        public int Search(int[] sortedArray, int value)
        {
            int left = 0; int right = sortedArray.Length - 1;
            while (left < right)
            {
                int middle = left + (right - left) / 2;
                int current = sortedArray[middle];
                if (current == value) return middle;

                if (current < value)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }

        public int SearchRecusive(int[] sortedArray, int value, int left, int right)
        {
            if (left >= right) return -1;

            int middle = left + (right - left) / 2;
            int current = sortedArray[middle];

            if (current == value) return middle;
            if (current < value)
            {
                return SearchRecusive(sortedArray, value, middle + 1, right);
            }

            return SearchRecusive(sortedArray, value, left, middle - 1);
        }


        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, 2, 1)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 3, 2)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 10, -1)]
        public void BinarySearchTest(int[] array, int value, int expectedIndex)
        {
            // Arrange
            // Act
            var result = Search(array, value);

            // Assert
            Assert.Equal(expectedIndex, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, 2, 1)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 3, 2)]
        [InlineData(new int[] { 1, 2, 3, 4 }, 10, -1)]
        public void BinarySearchRecursiveTest(int[] array, int value, int expectedIndex)
        {
            // Arrange
            // Act
            var result = SearchRecusive(array, value, 0, array.Length - 1);

            // Assert
            Assert.Equal(expectedIndex, result);
        }
    }
}
