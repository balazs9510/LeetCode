using Xunit;

namespace LeetCodeChallenges.Medium;

public class Merge_Intervals
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (a, b) => { return a[0] - b[0]; });
        int start = intervals[0][0];
        int end = intervals[0][1];
        var res = new List<int[]>();
        for (int i = 1; i < intervals.Length; i++)
        {
            var c = intervals[i];
            var cS = c[0];
            var cE = c[1];
            if (cS <= end)
            {
                if (cE > end)
                    end = cE;
            }
            else
            {
                res.Add([start, end]);
                start = cS;
                end = cE;
            }
        }
        res.Add([start, end]);

        return res.ToArray();
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void MergeTests(int[][] intervals, int[][] expected)
    {
        var res = Merge(intervals);

        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i][0], res[i][0]);
            Assert.Equal(expected[i][1], res[i][1]);
        }
    }

    public static IEnumerable<object[]> TestData => new List<object[]>
    {
        new object[] {
            new int[][] { [1, 3], [2, 6], [8, 10], [15, 18] },
            new int[][] { [1, 6], [8, 10], [15, 18] }},
        new object[] {
            new int[][] { [1, 4], [4, 5] },
            new int[][] { [1,5] }},
        new object[] {
            new int[][] { [1, 4], [0, 4] },
            new int[][] { [0,4] }},
    };
}
