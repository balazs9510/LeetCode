using Xunit;

namespace LeetCodeChallenges.Medium;

// TODO: O(n^2) is not properly functional
public class _4Sum
{
    #region O(n^3) solution
    public IList<IList<int>> FourSumPointers(int[] nums, int target)
    {
        Array.Sort(nums);
        var result = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 3; i++)
        {
            int first = nums[i];
            for (int j = i + 1; j < nums.Length - 2; j++)
            {
                int second = nums[j];
                long toFind = (long)(target - first - (long)second);
                var twoSums = FindTwoSumTwoPointer(nums.Skip(j + 1).ToArray(), toFind);

                foreach (var twoSum in twoSums)
                {
                    var fourSum = new List<int> { first, second };
                    fourSum.AddRange(twoSum);
                    if (!result.Any(x => Similar(4, x, fourSum)))
                        result.Add(fourSum);
                }
            }
        }

        return result;
    }

    private bool Similar(int length, IList<int> first, List<int> second)
    {
        bool similar = true;

        for (int i = 0; i < length; i++)
        {
            similar &= first[i] == second[i];
        }
        return similar;
    }

    private IList<IList<int>> FindTwoSumTwoPointer(int[] nums, long target)
    {
        var result = new List<IList<int>>();
        int left = 0; int right = nums.Length - 1;
        while (left < right)
        {
            long twoSum = (long)nums[left] + (long)nums[right];
            if (twoSum == target)
            {
                result.Add(new List<int> { nums[left], nums[right] });
                left++;
                right--;
            }
            else if (twoSum > target)
            {
                right--;
            }
            else
            {
                left++;
            }

        }

        return result;
    }

    #endregion

    #region O(n^2)

    private record Pair(int first, int second);

    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var result = new List<IList<int>>();
        Dictionary<long, Pair> pairSums = new Dictionary<long, Pair>();
        var temp = nums.Select(x => 0).ToList();

        // Iterate from 0 to temp.length 
        for (int i = 0; i < nums.Length; i++)
            temp[i] = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                long sum = nums[i] + (long)nums[j];
                var pair = new Pair(i, j);
                if (pairSums.ContainsKey(sum))
                {
                    pairSums[sum] = pair;
                }
                else
                {
                    pairSums.Add(sum, pair);
                }
            }
        }

        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                long sum = nums[i] + (long)nums[j];
                var diff = target - sum;
                if (pairSums.ContainsKey(diff))
                {
                    Pair pair = pairSums[diff];
                    if (pair.first != i && pair.first != j && pair.second != i && pair.second != j &&
                        temp[i] == 0 && temp[j] == 0 && temp[pair.first] == 0 && temp[pair.second] == 0)
                    {
                        var fourSum = new List<int> { nums[i], nums[j], nums[pair.first], nums[pair.second] };
                        result.Add(fourSum);
                        temp[pair.second] = 1;
                        temp[i] = 1;
                        temp[j] = 1;
                    }
                }
            }
        }

        return result;
    }

    #endregion

    [Fact]
    public void FourSumTest1()
    {
        // Arrange
        var data = new int[] { 1, 0, -1, 0, -2, 2 };
        var target = 0;
        var expected = new List<List<int>>
        {
            new List<int>{ -2,-1,1,2 },
            new List<int>{ -2,0,0,2 },
            new List<int>{ -1, 0, 0, 1 }
        };
        // Act
        var result = FourSum(data, target);

        // Assert
        for (int i = 0; i < expected.Count; i++)
        {
            for (int j = 0; j < expected[i].Count; j++)
            {
                Assert.Equal(expected[i][j], result[i][j]);
            }
        }
    }

    [Fact]
    public void FourSumTest2()
    {
        // Arrange
        var data = new int[] { 2, 2, 2, 2, 2 };
        var target = 8;
        var expected = new List<List<int>>
        {
            new List<int>{ 2,2,2,2 },
        };
        // Act
        var result = FourSum(data, target);

        // Assert
        for (int i = 0; i < expected.Count; i++)
        {
            for (int j = 0; j < expected[i].Count; j++)
            {
                Assert.Equal(expected[i][j], result[i][j]);
            }
        }
    }

    [Fact]
    public void FourSumTest3()
    {
        // Arrange
        var data = new int[] { -3, -2, -1, 0, 0, 1, 2, 3 };
        var target = 0;
        var expected = new List<List<int>>
        {
            new List<int>{ -3,-2,2,3 },
            new List<int>{ -3,-1,1,3},
            new List<int>{ -3,0,0,3 },
            new List<int>{ -3,0,1,2 },
            new List<int>{ -2,-1,0,3 },
            new List<int>{ -2,-1,1,2 },
            new List<int>{ -2,0,0,2 },
            new List<int>{ -1,0,0,1 },
        };
        // Act
        var result = FourSum(data, target);

        // Assert
        for (int i = 0; i < expected.Count; i++)
        {
            for (int j = 0; j < expected[i].Count; j++)
            {
                Assert.Equal(expected[i][j], result[i][j]);
            }
        }
    }

    [Fact]
    public void FourSumTest4()
    {
        // Arrange
        var data = new int[] { 1000000000, 1000000000, 1000000000, 1000000000 };
        var target = -294967296;
        var expected = new List<List<int>>
        {

        };
        // Act
        var result = FourSum(data, target);

        // Assert
        for (int i = 0; i < expected.Count; i++)
        {
            for (int j = 0; j < expected[i].Count; j++)
            {
                Assert.Equal(expected[i][j], result[i][j]);
            }
        }
    }
}


