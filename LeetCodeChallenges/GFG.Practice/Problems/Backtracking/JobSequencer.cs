using System.Collections;
using Xunit;

namespace GFG.Practice.Problems.Backtracking;

public record Job(char id, int deadline, int profit) : IComparable<Job>
{
    public int CompareTo(Job other)
    {
        if (profit > other.profit) return -1;
        if (profit < other.profit) return 1;

        return 0;
    }
}




/// <summary>
/// Returns jobs with the max profit. O(N^2)
/// </summary>
public class JobSequencer : IEnumerable<Job>
{
    private List<Job> _jobsToTake;

    public JobSequencer(List<Job> jobs, int jobsToTake)
    {
        MaxProfitSequence(jobs, jobsToTake);
    }

    private void MaxProfitSequence(List<Job> jobs, int jobsToTake)
    {
        // Default compare will do the decreasing order
        jobs.Sort();
        var c = jobs.Count;
        var lookup = new bool[jobsToTake].AsSpan();
        var jobIds = new Job[jobsToTake];
        for (int i = 0; i < c; i++)
        {
            for (int j = Math.Min(c - 1, jobs[i].deadline - 1); j >= 0; j--)
            {
                if (!lookup[j])
                {
                    lookup[j] = true;
                    jobIds[j] = jobs[i];
                    break;
                }
            }
        }
        _jobsToTake = new List<Job>(jobIds);
    }

    public IEnumerator<Job> GetEnumerator()
    {
        return _jobsToTake.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class JobSequenceTests
{

    [Fact]
    public void SimpleTest()
    {
        // Arrange
        List<Job> arr = new List<Job>();

        arr.Add(new Job('a', 2, 100));
        arr.Add(new Job('b', 1, 19));
        arr.Add(new Job('c', 2, 27));
        arr.Add(new Job('d', 1, 25));
        arr.Add(new Job('e', 3, 15));

        // Act

        var result = new JobSequencer(arr, 3);
        var sum = result.Select(x => x.profit).Sum();

        // Assert
        Assert.Equal(142, sum);
    }
}