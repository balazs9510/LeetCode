using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Easy;

public class Implement_Queue_using_Stacks
{
    public class MyQueue
    {
        private readonly Stack<int> _enqueue = new Stack<int>();
        private readonly Stack<int> _dequeue = new Stack<int>();

        public MyQueue()
        {

        }

        public void Push(int x)
        {
            _enqueue.Push(x);
        }

        public int Pop()
        {
            CopyFromEnqueueToDequeue();

            return _dequeue.Pop();
        }

        private void CopyFromEnqueueToDequeue()
        {
            if (_dequeue.Count == 0)
            {
                while (_enqueue.Count > 0)
                {
                    _dequeue.Push(_enqueue.Pop());
                }
            }
        }

        public int Peek()
        {
            CopyFromEnqueueToDequeue();

            return _dequeue.Peek();
        }

        public bool Empty()
        {
            return (_enqueue.Count + _dequeue.Count) == 0;
        }
    }


    [Fact]
    public void CanPushOne()
    {
        // Arrange
        var queue = new MyQueue();

        // Act
        queue.Push(1);

        // Assert
        Assert.Equal(1, queue.Peek());
    }

    [Fact]
    public void CanPushMultiple()
    {
        // Arrange
        var queue = new MyQueue();

        // Act
        queue.Push(1);
        queue.Push(2);
        queue.Push(3);

        // Assert
        Assert.Equal(1, queue.Pop());
        Assert.Equal(2, queue.Pop());
        Assert.Equal(3, queue.Pop());
    }

    [Fact]
    public void EmptyOnInit()
    {
        // Arrange
        var queue = new MyQueue();

        // Act
        var result = queue.Empty();

        // Assert
        Assert.True(result);
    }


    [Fact]
    public void EmptyAfterPop()
    {
        // Arrange
        var queue = new MyQueue();

        // Act
        queue.Push(1);
        queue.Pop();

        var result = queue.Empty();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void PushAfterPop()
    {
        // Arrange
        var queue = new MyQueue();

        // Act
        queue.Push(1);
        queue.Pop();
        queue.Push(2);

        var result = queue.Pop();

        // Assert
        Assert.Equal(2, result);
    }
}
