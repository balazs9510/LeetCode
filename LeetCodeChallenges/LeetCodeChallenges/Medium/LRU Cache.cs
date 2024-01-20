using LeetCodeChallenges.Utils;
using Xunit;

namespace LeetCodeChallenges.Medium;

public class LRUCache
{
    private class CacheEntry
    {
        public CacheEntry(int key, int value, CacheEntry next = null, CacheEntry prev = null)
        {
            Key = key;
            Value = value;
            Next = next;
            Prev = prev;
        }

        public int Key { get; }
        public int Value { get; set; }
        public CacheEntry Next { get; set; }
        public CacheEntry Prev { get; set; }
    }

    private readonly int _capacity;
    private CacheEntry _dummyHead;
    private CacheEntry _dummyTail;
    private readonly Dictionary<int, CacheEntry> _nodes = new Dictionary<int, CacheEntry>();

    public int Count => _nodes.Count;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _dummyHead = new CacheEntry(int.MinValue, 0);
        _dummyTail = new CacheEntry(int.MaxValue, 0, null, _dummyHead);
    }

    public int Get(int key)
    {
        if (_nodes.ContainsKey(key))
        {
            var current = RemoveNode(key);

            Put(current.Key, current.Value);

            return current.Value;

        }
        return -1;
    }

    private CacheEntry RemoveNode(int key)
    {
        var current = _nodes[key];
        _nodes.Remove(key);

        current.Prev.Next = current.Next;
        current.Next.Prev = current.Prev;

        return current;
    }

    public void Put(int key, int value)
    {
        if (_nodes.ContainsKey(key))
        {
            RemoveNode(key);
        }

        var newTail = new CacheEntry(key, value);
        var oldTail = _dummyTail.Prev;
        _dummyTail.Prev = newTail;
        oldTail.Next = newTail;
        newTail.Prev = oldTail;
        newTail.Next = _dummyTail;
        _nodes.Add(newTail.Key, newTail);


        if (Count > _capacity)
        {
            _nodes.Remove(_dummyHead.Next.Key);
            _dummyHead.Next = _dummyHead.Next.Next;
            _dummyHead.Next.Prev = _dummyHead;
        }
    }
}

public class Tests
{

    [Fact]
    public void SimpleTest()
    {
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.Put(1, 1); // cache is {1=1}
        lRUCache.Put(2, 2); // cache is {1=1, 2=2}
        Assert.Equal(1, lRUCache.Get(1));    // return 1
        lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        Assert.Equal(-1, lRUCache.Get(2));    // returns -1 (not found)
        lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        Assert.Equal(-1, lRUCache.Get(1));    // return -1 (not found)
        Assert.Equal(3, lRUCache.Get(3));    // return 3
        Assert.Equal(4, lRUCache.Get(4));    // return 4
    }

    [Fact]
    public void SimpleTest2()
    {
        LRUCache lRUCache = new LRUCache(1);
        lRUCache.Put(2, 1); // cache is {2=1}
        Assert.Equal(1, lRUCache.Get(2));    // return 1
        lRUCache.Put(3, 2); // cache is {3=2}
        Assert.Equal(-1, lRUCache.Get(2));    // returns 1
        Assert.Equal(2, lRUCache.Get(3));    // returns 1

    }

    [Fact]
    public void SimpleTest3()
    {
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.Put(2, 1); // cache is {2=1}
        lRUCache.Put(2, 2); // cache is {2=2}
        Assert.Equal(2, lRUCache.Get(2));    // return 2
        lRUCache.Put(1, 1); // cache is {2=2, 1=1}
        lRUCache.Put(4, 1); // cache is {1=1, 4=1}
        Assert.Equal(-1, lRUCache.Get(2));    // returns -1
    }

    [Fact]
    public void SimpleTest4()
    {
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.Put(2, 1); 
        lRUCache.Put(1, 1);
        lRUCache.Put(2, 3); 
        lRUCache.Put(4, 1); 
        Assert.Equal(-1, lRUCache.Get(1));   
        Assert.Equal(3, lRUCache.Get(2));   
    }

}