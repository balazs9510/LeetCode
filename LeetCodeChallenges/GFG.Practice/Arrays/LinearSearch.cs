using Xunit;

namespace GFG.Practice.Arrays
{
    public class LinearSearch
    {
        public int Search(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }


        [Theory]
        [InlineData(new int[] { 1,2,3,4}, 2, 1)]
        [InlineData(new int[] { 1,2,3,4}, 3, 2)]
        [InlineData(new int[] { 1,2,3,4}, 10, -1)]
        public void LinearSearchTest(int[] array, int value, int expectedIndex)
        {
            // Arrange
            // Act
            var result = Search(array, value);

            // Assert
            Assert.Equal(expectedIndex, result);
        }
    }
}
