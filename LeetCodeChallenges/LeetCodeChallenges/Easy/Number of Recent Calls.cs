using Xunit;

namespace LeetCodeChallenges.Easy;

public class Number_of_Recent_Calls
{
    public class RecentCounter
    {
        private readonly Queue<int> _queue = new Queue<int>();

        public RecentCounter()
        {

        }

        public int Ping(int t)
        {
            _queue.Enqueue(t);

            while (_queue.Peek() < t - 3000)
            {
                _queue.Dequeue();
            }

            return _queue.Count;
        }
    }


    [Fact]
    public void MyTestMethod()
    {
        // Arrange
        RecentCounter recentCounter = new RecentCounter();
        // Act
        // Assert
        var res = recentCounter.Ping(1);     // requests = [1], range is [-2999,1], return 1
        Assert.Equal(1, res);
        res = recentCounter.Ping(100);   // requests = [1, 100], range is [-2900,100], return 2
        Assert.Equal(2, res);
        res = recentCounter.Ping(3001);  // requests = [1, 100, 3001], range is [1,3001], return 3
        Assert.Equal(3, res);
        res = recentCounter.Ping(3002);  // requests = [1, 100, 3001, 3002], range is [2,3002], return 3
        Assert.Equal(3, res);
    }
}
