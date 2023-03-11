namespace LeetCodeChallenges.Medium
{
    public partial class MediumSolution
    {
	    private static MediumSolution? _instance;

	    public static MediumSolution Instance
	    {
		    get
		    {
			    if (_instance == null)
			    {
				    _instance = new MediumSolution();
			    }
			    return _instance;
		    }
	    }

	    private MediumSolution()
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
