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
			return RegexRecursive(s, p, s.Length - 1, p.Length - 1);
		}

		private bool RegexRecursive(string s, string p, int sIterator, int pIterator)
		{
			// both string checked trough
			if (sIterator < 0 && pIterator < 0) return true;
			// p fully checked but s not or s fully checked but p not and it doesn't a quantifier end
			if (pIterator < 0 || (sIterator < 0 && p[pIterator] != '*')) return false;
			// s fully checked but quantifier at the end so we have to check if there are still more items in p
			if (sIterator < 0 && p[pIterator] == '*') return RegexRecursive(s, p, sIterator, pIterator - 2);

			if (s[sIterator] == p[pIterator] || p[pIterator] == '.') return RegexRecursive(s, p, sIterator - 1, pIterator - 1);
			// if the current symbols are not matching and the pattern doesn't end to asterisk
			if (p[pIterator] != '*') return false;

			if (s[sIterator] == p[pIterator - 1] || p[pIterator - 1] == '.')
			{
				var result = RegexRecursive(s, p, sIterator - 1, pIterator);
				if (!result) return RegexRecursive(s, p, sIterator, pIterator - 2);
				
				return true;
			}

			return false;
		}

		public static void IsMatchingRegularExpressionTests()
		{
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("c", "a*b*c"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaabc", "a*b*c"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaabc", "a*ab*c"));
			//WriteTestToConsole(false, Instance.IsMatchingRegularExpression("aa", "a*b"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aab", "a*b"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaaaaaaaab", "a*b"));
			//WriteTestToConsole(true, Instance.IsMatchingRegularExpression("adsadsadadab", "a.*b"));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("mississippi", "mis*is*ip*."));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("adsadsadadabc", "a.*bc"));
			WriteTestToConsole(false, Instance.IsMatchingRegularExpression("adsadsadadabc", "a.*b"));
			WriteTestToConsole(false, Instance.IsMatchingRegularExpression("cb", "a*b"));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("ab", "a.*b"));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaa", "a*a"));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("b", "a*b"));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aab", "a*b"));
			WriteTestToConsole(false, Instance.IsMatchingRegularExpression("aa", "a*b"));
			WriteTestToConsole(false, Instance.IsMatchingRegularExpression("bb", "a*b"));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aa", "a*"));
			WriteTestToConsole(false, Instance.IsMatchingRegularExpression("aa", "a"));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aaba", "aa.a"));
			WriteTestToConsole(true, Instance.IsMatchingRegularExpression("aa", "a."));
			WriteTestToConsole(false, Instance.IsMatchingRegularExpression("aa", "aab"));
		}

	}
}
