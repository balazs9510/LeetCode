using Xunit;

namespace LeetCodeChallenges.Easy;

public class Implement_Stack_using_Queues
{
    public class MyStack
    {
        private Queue<int> _queue = new Queue<int>();

        public MyStack()
        {

        }

        public void Push(int x)
        {
            _queue.Enqueue(x);
            var count = _queue.Count;
            for (int i = 0; i < count - 1; i++)
            {
                _queue.Enqueue(_queue.Dequeue());
            }
        }

        public int Pop()
        {
            return _queue.Dequeue();
        }

        public int Top()
        {
            return _queue.Peek();
        }

        public bool Empty()
        {
            return (_queue.Count == 0);
        }
    }

    public class MyStackTests
    {
        [Fact]
        public void SimplePushOrderTest()
        {
            // Arrange
            var stack = new MyStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            var item = stack.Pop();

            // Assert
            Assert.Equal(3, item);
        }

        [Fact]
        public void DoublePopOrderTest()
        {
            // Arrange
            var stack = new MyStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            stack.Pop();
            var item = stack.Pop();

            // Assert
            Assert.Equal(2, item);
        }


        [Fact]
        public void NotEmptyTest()
        {
            // Arrange
            var stack = new MyStack();
            stack.Push(1);
            stack.Push(1);
            stack.Push(1);
            // Act
            var res = stack.Empty();

            // Assert
            Assert.False(res);
        }

        [Fact]
        public void EmptyTest()
        {
            // Arrange
            var stack = new MyStack();
            stack.Push(1);
            stack.Pop();
            // Act
            var res = stack.Empty();

            // Assert
            Assert.True(res);
        }
    }
}
