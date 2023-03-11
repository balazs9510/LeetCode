using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeChallenges.Easy
{
    public partial class EasySolution
    {
        public bool IsValidParentheses(string s)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];
                if (IsOpening(current))
                {
                    stack.Push(current);
                }
                else
                {
                    if (stack.Count == 0) return false;
                    char toCheck  = stack.Pop();
                    if (GetClosing(toCheck) != current)
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }


        private char GetClosing(char c)
        {
            switch (c)
            {
                case '(': return ')';
                case '[': return ']';
                case '{': return '}';
            }
            throw new ArgumentOutOfRangeException();
        }

        private bool IsOpening(char c)
        {
            return c == '(' || c == '[' || c == '{';
        }

        public static void IsValidParenthesesTests()
        {
            //Console.WriteLine(Instance.IsValidParentheses("()"));
            //Console.WriteLine(Instance.IsValidParentheses("()[]{}"));
            //Console.WriteLine(Instance.IsValidParentheses("(]"));
            //Console.WriteLine(Instance.IsValidParentheses("({{[[]]{}}])"));
            //Console.WriteLine(Instance.IsValidParentheses("()("));
        }
    }
}
