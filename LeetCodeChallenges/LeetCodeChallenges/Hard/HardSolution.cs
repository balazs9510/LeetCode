using Console = System.Console;

namespace LeetCodeChallenges.Hard
{
    public partial class HardSolution
    {
        private static HardSolution? _instance;

        public static HardSolution Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HardSolution();
                }
                return _instance;
            }
        }

        private HardSolution()
        {

        }

        private static void WriteTestToConsole<T>(T expected, T actual)
        {
            Console.WriteLine($"Expected: {expected}; Actual: {actual}");
            if (actual.ToString() != expected.ToString())
            {
                Console.Error.WriteLine("Not matching!");
            }
        }
    }
}
