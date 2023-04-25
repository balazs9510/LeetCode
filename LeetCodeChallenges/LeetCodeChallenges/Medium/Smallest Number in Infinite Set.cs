using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LeetCodeChallenges.Medium
{
    public class Smallest_Number_in_Infinite_Set
    {
        public class SmallestInfiniteSet
        {
            private LinkedList<int> _pointers = new LinkedList<int>();
            private int _popCounter = 1;
            public SmallestInfiniteSet()
            {
                _pointers.AddFirst(1);
            }

            public int PopSmallest()
            {
                var first = _pointers.First;
                _pointers.RemoveFirst();

                if (_pointers.First == null)
                {
                    _pointers.AddFirst(++_popCounter);
                }

                return first?.Value ?? 0;
            }

            public void AddBack(int num)
            {
                if (num > _popCounter) return;

                var iterator = _pointers.First!;

                while (iterator!.Value < num)
                {
                    iterator = iterator.Next;
                }

                if (iterator!.Value == num)
                {
                    // if its higher 
                    return;
                }

                _pointers.AddBefore(iterator, num);
            }
        }

        [Fact]
        public void SmallestInfiniteSetTest()
        {
            SmallestInfiniteSet smallestInfiniteSet = new SmallestInfiniteSet();
            smallestInfiniteSet.AddBack(2);    // 2 is already in the set, so no change is made.
            Assert.Equal(1,smallestInfiniteSet.PopSmallest()); // return 1, since 1 is the smallest number, and remove it from the set.
            Assert.Equal(2, smallestInfiniteSet.PopSmallest()); // return 2, and remove it from the set.
            Assert.Equal(3, smallestInfiniteSet.PopSmallest()); // return 3, and remove it from the set.
            smallestInfiniteSet.AddBack(1);    // 1 is added back to the set.
            Assert.Equal(1, smallestInfiniteSet.PopSmallest()); // return 1, since 1 was added back to the set and
                                                                // is the smallest number, and remove it from the set.
            Assert.Equal(4, smallestInfiniteSet.PopSmallest()); // return 4, and remove it from the set.
            Assert.Equal(5, smallestInfiniteSet.PopSmallest()); // return 5, and remove it from the set.
        }

        [Fact]
        public void SmallestInfiniteSetTest2()
        {
            SmallestInfiniteSet smallestInfiniteSet = new SmallestInfiniteSet();
            smallestInfiniteSet.AddBack(2);   
            Assert.Equal(1, smallestInfiniteSet.PopSmallest()); 
            Assert.Equal(2, smallestInfiniteSet.PopSmallest()); 
            Assert.Equal(3, smallestInfiniteSet.PopSmallest()); 
            smallestInfiniteSet.AddBack(1);
            smallestInfiniteSet.AddBack(3); 
            Assert.Equal(1, smallestInfiniteSet.PopSmallest());
            Assert.Equal(3, smallestInfiniteSet.PopSmallest());
            Assert.Equal(4, smallestInfiniteSet.PopSmallest()); 
            Assert.Equal(5, smallestInfiniteSet.PopSmallest()); 
        }


    }
}
