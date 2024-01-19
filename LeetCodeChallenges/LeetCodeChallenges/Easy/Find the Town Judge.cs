using Xunit;

namespace LeetCodeChallenges.Easy;

public class Find_the_Town_Judge
{
    public record Person(int n, HashSet<int> trustIn, HashSet<int> trustOut);

    public int FindJudge(int n, int[][] trust)
    {
        var dict = Enumerable.Range(1, n).Select(x => new Person(x, new HashSet<int>(), new HashSet<int>())).ToDictionary((p) => p.n);

        for (var i = 0; i < trust.Length; i++)
        {
            var currentTrust = trust[i];
            var truster = dict[currentTrust[0]];
            truster.trustOut.Add(currentTrust[1]);
            var trusted = dict[currentTrust[1]];
            trusted.trustIn.Add(currentTrust[0]);
        }

        var judge = dict.Values.FirstOrDefault(x => x.trustOut.Count == 0 && x.trustIn.Count == n - 1);
        return judge?.n ?? -1;
    }


    [Theory]
    [MemberData(nameof(TestData))]
    public void FindJudgeTests(int n, int[][] trust, int expected)
    {
        // Arrange
        // Act
        // Assert
        Assert.Equal(expected, FindJudge(n, trust));
    }

    public static IEnumerable<Object[]> TestData => new List<object[]>
    {
        new object[] {2, new int[][] { new int[] { 1, 2 } }, 2 },
        new object[] {3, new int[][] { new int[] { 1, 3 }, new int[] { 2,3 } }, 3 },
        new object[] {3, new int[][] { new int[] { 1, 3 }, new int[] { 2,3 }, new int[] { 3,1 } }, -1 }
    };
}
