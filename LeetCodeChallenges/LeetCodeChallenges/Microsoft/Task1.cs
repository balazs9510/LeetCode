using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Microsoft
{
    public class Task1
    {
        public int solution(int[] A)
        {
            // initial idea is going trough the array, creating the pairs, marking them, moving to next possible
            // I'll do it in VS22
            int count = 0;
            bool firstPaired = false, lastPaired = false;
            for (int i = 0; i < A.Length - 1; i++)
            {
                if ((A[i] + A[i + 1]) % 2 == 0)
                {
                    count++;
                    if (i == 0) firstPaired = true;
                    if (i == A.Length - 2) lastPaired = true;
                    i++;
                }
            }

            if (!firstPaired && !lastPaired)
            {
                if ((A[0] + A[A.Length - 1]) % 2 == 0)
                {
                    count++;
                }
            }
            
            return count;
        }

        [Theory]
        [InlineData(new int[] { 4, 2, 5, 8, 7, 3, 7 }, 2)]
        [InlineData(new int[] { 14, 21, 16, 35, 22 }, 1)]
        [InlineData(new int[] { 5,5,5,5,5,5 }, 3)]
        public void Task1Tests(int[] A, int expected)
        {
            // Arrange act
            var res = solution(A);

            Assert.Equal(expected, res);
        }
    }
}
