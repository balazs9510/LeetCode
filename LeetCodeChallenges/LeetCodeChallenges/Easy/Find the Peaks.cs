using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Find_the_Peaks
    {
        public IList<int> FindPeaks(int[] mountain)
        {
            var result = new List<int>();

            for (int i = 1; i < mountain.Length - 1; i++)
            {
                var prev = mountain[i - 1]; var current = mountain[i]; var next = mountain[i + 1];
                if (prev < current && current > next)
                {
                    result.Add(i);
                }
            }
            return result;
        }


        [Theory]
        [InlineData(new int[] { 2, 4, 4 }, new int[] { })]
        [InlineData(new int[] { 1, 4, 3, 8, 5 }, new int[] { 1, 3 })]
        public void FindPeaksTests(int[] mountain, int[] expected)
        {
            // Arrange
            // Act
            var result = FindPeaks(mountain);

            // Assert
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }
    }
}
