using Xunit;

namespace LeetCodeChallenges.Easy;

public class Isomorphic_Strings
{
    public bool IsIsomorphic(string s, string t)
    {
		if (s.Length != t.Length) return false;
		var set = new HashSet<char>();
		var map = new Dictionary<char, char>();

		for (int i = 0; i < s.Length; i++)
		{
			if (map.ContainsKey(s[i]) && map[s[i]] != t[i]) return false;

			bool notMapped = !map.ContainsKey(s[i]);

            if (set.Contains(t[i]) && notMapped) return false;

			if (notMapped)
			{
                set.Add(t[i]); map.Add(s[i], t[i]);
            }
        }
		return true;
    }

	[Theory]
	[InlineData("egg", "add", true)]
	[InlineData("foo", "bar", false)]
	[InlineData("paper", "title", false)]
	public void IsIsomorphicTests(string s, string t, bool expected)
	{
		// Arrange
		// Act
		var result = IsIsomorphic(s, t);
        // Assert
        Assert.Equal(expected, result);
    }
   
}
