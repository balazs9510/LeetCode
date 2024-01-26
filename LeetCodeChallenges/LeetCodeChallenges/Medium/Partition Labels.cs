using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Medium;

public class Partition_Labels
{
    public class Appereance
    {
        public char c;
        public int first;
        public int last;

        public Appereance(char c, int first, int last)
        {
            this.c = c;
            this.first = first;
            this.last = last;
        }
    }

    public IList<int> PartitionLabels(string s)
    {
        var dict = new Dictionary<char, Appereance>();

        for (int i = 0; i < s.Length; i++)
        {
            if (dict.ContainsKey(s[i]))
            {
                dict[s[i]].last = i;
            }
            else
            {
                dict[s[i]] = new Appereance(s[i], i, i);
            }
        }
        var apps = dict.Values.OrderBy(x => x.first).ToList();
        var result = new List<int>();

        var max = 0;
        var min = 0;
        for (int i = 0; i < apps.Count; i++)
        {
            var current = apps[i];
            if (current.first > max)
            {
                result.Add(max - min + 1);
                min = current.first;
                max = current.last;
            }
            if (current.last > max)
            {
                max = current.last;
            }
        }
        result.Add(max - min + 1);
        return result;
    }


    [Theory]
    [InlineData("ababcbacadefegdehijhklij", new int[] { 9, 7, 8 })]
    [InlineData("eccbbbbdec", new int[] { 10 })]
    [InlineData("aaaaaab", new int[] { 6,1 })]
    [InlineData("a", new int[] { 1 })]
    public void PartitionLabelsTests(string s, int[] expected)
    {
        // Arrange


        // Act


        // Assert
        AssertUtils.AssertTwoArraysIsEqual(expected, PartitionLabels(s).ToArray());
    }
}
