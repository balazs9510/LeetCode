using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Container_With_Most_Water
    {
        // Fastest implementation: increase left pointer if left < rigth else decrease left pointer
        public int MaxArea(int[] height)
        {
            var max = 0;
            var lMax = 0;
            if (height.Length == 0) return 0;
            if (height.Length == 1) return height[0];

            for (int i = 0; i < height.Length - 1; i++)
            {
                if (height[i] > lMax)
                {
                    lMax = height[i];
                    for (int j = i + 1; j < height.Length; j++)
                    {
                        var current = GetAreaBetweenIndeces(i, j, height);
                        if (current > max)
                        {
                            max = current;
                        }
                    }
                }
            }

            return max;
        }

        private int GetAreaBetweenIndeces(int x, int y, int[] height)
        {
            var height1 = height[x];
            var height2 = height[y];
            var areaMaxHeight = Math.Min(height1, height2);

            return areaMaxHeight * (y - x);
        }

        [Theory]
        [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [InlineData(new int[] { 1, 1 }, 1)]
        [InlineData(new int[] { 10000, 1, 10000 }, 20000)]
        public void MaxAreaTests(int[] heights, int expectedOutcome)
        {
            // Arrange & act
            var result = MaxArea(heights);

            // Assert
            Assert.Equal(expectedOutcome, result);
        }
    }
}
