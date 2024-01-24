using Xunit;

namespace LeetCodeChallenges.Easy;

public class Happy_Number
{
    public bool IsHappy(int n)
    {
        bool found = false;
        var set = new HashSet<int>();
        while (!found)
        {

            if (n == 1) found = true;

            var nString = n.ToString().ToArray();
            //var left = 0; var right = nString.Length - 1;
            n = nString.Select(x => int.Parse(x.ToString()) * int.Parse(x.ToString())).Sum();
            if (set.Contains(n)) break;
            set.Add(n);
        }

        return found;
    }


    [Theory]
    [InlineData(19, true)]
    [InlineData(2, false)]
    [InlineData(int.MaxValue, false)]
    public void IsHappyTest(int n, bool expected)
    {
        // Arrange
        // Act
        // Assert
        Assert.Equal(expected, IsHappy(n));
    }
}
