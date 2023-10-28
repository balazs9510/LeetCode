using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class _3Sum_Closest
    {
        public int ThreeSumClosest(int[] nums, int target)
        {
            var count = nums.Length;
            var closestSumToTarget = 0;
            var distFromTarget = int.MaxValue;
            for (var i = 0; i < count - 2; i++)
            {
                var first = nums[i];
                for (var j = i + 1; j < count - 1; j++)
                {
                    var second = nums[j];
                    for (var k = j + 1; k < count; k++)
                    {
                        var third = nums[k];
                        var currentSum = first + second + third;
                        if (Math.Abs(target - currentSum) < distFromTarget)
                        {
                            distFromTarget = Math.Abs(target - currentSum);
                            closestSumToTarget = currentSum;
                        }
                    }
                }
            }
            return closestSumToTarget;
        }

        [Fact]
        public void MyTestMethod()
        {
            // Arrange
            var nums = new[] { -1, 2, 1, -4 };

            // Act
            var result = ThreeSumClosest(nums, 1);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void MyTestMethod2()
        {
            // Arrange
            var nums = new[] { 0, 0, 0 };

            // Act
            var result = ThreeSumClosest(nums, 1);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void MyTestMethod3()
        {
            // Arrange
            var nums = new[] { 0, 1, 3, 6, 9 };

            // Act
            var result = ThreeSumClosest(nums, 1);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void MyTestMethod4()
        {
            // Arrange
            var nums = new[] { 0, 1, 3, 6, 9 };

            // Act
            var result = ThreeSumClosest(nums, 4);

            // Assert
            Assert.Equal(4, result);
        }
    }
}
