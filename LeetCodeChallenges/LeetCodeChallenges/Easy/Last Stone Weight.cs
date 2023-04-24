using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy
{
    public class Last_Stone_Weight
    {
        public int LastStoneWeight(int[] stones)
        {
            var list = new LinkedList<int>();

            var orderedStonnes = stones.OrderByDescending(x => x);
            foreach (var stone in orderedStonnes)
            {
                list.AddLast(stone);
            }
            while (list.Count > 1)
            {
                var high = list.First;
                var low = high.Next;

                if (low.Value == high.Value)
                {
                    list.Remove(high);
                    list.Remove(low);
                }
                else
                {
                    var newValue = high.Value - low.Value;
                    list.Remove(high);
                    list.Remove(low);
                    var iterator = list.First;
                    if (iterator == null)
                    {
                        list.AddFirst(newValue);
                    }
                    else
                    {
                        while (newValue < iterator?.Value)
                        {
                            iterator = iterator.Next;
                        }
                        if (iterator == null)
                        {
                            list.AddLast(newValue);
                        }
                        else
                        {
                            list.AddBefore(iterator, newValue);
                        }
                    }
                }
            }
            return list.First?.Value ?? 0;
        }

        [Theory]
        [InlineData(new int[] { 2, 7, 4, 1, 8, 1 }, 1)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 500, 2 }, 498)]
        [InlineData(new int[] { 500, 498, 2 }, 0)]
        [InlineData(new int[] { 3, 7, 8 }, 2)]
        public void LastStoneWeightTests(int[] stones, int expected)
        {
            // Arrange & act
            var res = LastStoneWeight(stones);

            // Assert
            Assert.Equal(expected, res);
        }
    }
}
