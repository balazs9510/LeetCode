using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Hard
{
    public partial class HardSolution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            bool isEven = (nums1.Length + nums2.Length) % 2 == 0;
            int middle = (nums1.Length + nums2.Length) / 2 + 1;
            int i1 = 0, i2 = 0;
            double res = 0;

            for (int i = 0; i < middle; i++)
            {
                if (i1 >= nums1.Length)
                {
                    if (!isEven && i == middle - 1) return nums2[i2];

                    if (i == middle - 2)
                    {
                        res = nums2[i2];
                    }
                    if (i == middle - 1)
                    {
                        res += nums2[i2];
                    }
                    i2++;
                    continue;
                }
                if (i2 >= nums2.Length)
                {
                    if (!isEven && i == middle - 1) return nums1[i1];

                    if (i == middle - 2)
                    {
                        res = nums1[i1];
                    }
                    if (i == middle - 1)
                    {
                        res += nums1[i1];
                    }
                    i1++;
                    continue;
                }


                int num1 = nums1[i1];
                int num2 = nums2[i2];
                if (num1 < num2)
                {
                    if (!isEven && i == middle - 1) return nums1[i1];

                    if (i == middle - 2)
                    {
                        res = nums1[i1];
                    }
                    if (i == middle - 1)
                    {
                        res += nums1[i1];
                    }
                    i1++;
                }
                else
                {
                    if (!isEven && i == middle - 1) return nums2[i2];

                    if (i == middle - 2)
                    {
                        res = nums2[i2];
                    }
                    if (i == middle - 1)
                    {
                        res += nums2[i2];
                    }
                    i2++;
                }
            }

            return res / (double)2;
        }
    }
}
