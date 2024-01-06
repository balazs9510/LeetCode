using Xunit;

namespace GFG.Practice.Arrays
{
    public class ArrayUtilsTests
    {

        [Fact]
        public void RevesreArrayTests()
        {
            // Arrange
            int[] array = new int[] { 1, 2, 3, 4 };

            // Act
            var result = ArrayUtils.Reverse(array);

            // Assert
            Assert.Equal(4, result[0]);
            Assert.Equal(3, result[1]);
            Assert.Equal(2, result[2]);
            Assert.Equal(1, result[3]);
        }
    }
}
