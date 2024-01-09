using Xunit;

namespace LeetCodeChallenges.Microsoft
{
    public class Task3
    {
        public int solution(string S)
        {
            return CheckForDiagramLengths(S);
        }

        [Theory]
        [InlineData("aakmaakmakda", 7)]
        [InlineData("aaa", 1)]
        [InlineData("codility", -1)]
        public void Task3Tests(string S, int expected)
        {
            var res = solution(S);

            Assert.Equal(expected, res);
        }

        public int CheckForDiagramLengths(string S)
        {
            var dict = new Dictionary<string, int>();
            var maxDist = -1;
            for (int i = 0; i < S.Length - 1; i++)
            {
                var diagram = S[i].ToString() + S[i + 1];
                if (dict.ContainsKey(diagram))
                {
                    var dist = i - dict[diagram];
                    if (dist > maxDist)
                        maxDist = dist;
                }
                else
                {
                    dict.Add(diagram, i);
                }
                // a ak maakm ak da
            }

            return maxDist;
        }
    }
}
