using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Hard
{
	public partial class HardSolution
	{
		public bool IsMatchingRegularExpression(string s, string p)
		{
			string[] quantifierGroups = p.Split('*');
			int quantifierGroupsIterator = 0;
			int groupIterator = 0;
			for (int i = 0; i < s.Length; i++)
			{
				char currentChar = s[i];
				string group = quantifierGroups[quantifierGroupsIterator];
				if (group.Length == 0 || groupIterator >= group.Length) return false;

				char toCheck = group[groupIterator];
				if (groupIterator < group.Length - 1 ||
					quantifierGroupsIterator == quantifierGroups.Length - 1)
				{
					if (groupIterator >= group.Length) return false;
					if (toCheck != '.' && toCheck != currentChar) return false;

					groupIterator++;
				}
				else
				{
					if (toCheck != '.' && toCheck != currentChar)
					{
						quantifierGroupsIterator++;
						groupIterator = 0;
						i--;
					}

					if (quantifierGroupsIterator + 1 < quantifierGroups.Length)
					{
						string nextGroup = quantifierGroups[quantifierGroupsIterator + 1];
						if (nextGroup.Length > 0 && nextGroup[0] == toCheck)
						{
							quantifierGroups[quantifierGroupsIterator + 1] = nextGroup.Substring(1);
						}
					}
				}
			}

			return quantifierGroups.Last().Length == groupIterator;
		}

		public static void IsMatchingRegularExpressionTests()
		{
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("c", "a*b*c"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaabc", "a*b*c"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaabc", "a*ab*c"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaa", "a*a"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aa", "a*"));
			//WriteTestToConsole(false, Instance.IsMatchingRegularExpression("aa", "a*b"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aab", "a*b"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaaaaaaaab", "a*b"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("b", "a*b"));
			//WriteTestToConsole(false, Instance.IsMatchingRegularExpression("cb", "a*b"));
			//WriteTestToConsole(false, Instance.IsMatchingRegularExpression("bb", "a*b"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("ab", "a.*b"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("adsadsadadab", "a.*b"));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("adsadsadadabc", "a.*bc"));
			WriteTestToConsole(false, Instance.IsMatchingRegularExpression("adsadsadadabc", "a.*b"));
			WriteTestToConsole(false, Instance.IsMatchingRegularExpression("aa", "a"));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaba", "aa.a"));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aa", "a."));
			WriteTestToConsole(false, Instance.IsMatchingRegularExpression("aa", "aab"));
		}

	}
}
