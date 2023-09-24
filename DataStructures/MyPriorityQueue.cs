namespace DataStructures;

public class MyPriorityQueue<T>
{
    private readonly MyBinaryHeap<(T Item, int Priority)> _heap;

    public MyPriorityQueue(int capacity = 64)
    {
        _heap = new MyBinaryHeap<(T Item, int Priority)>(capacity,
            Comparer<(T Item, int Priority)>.Create((x, y) => x.Priority.CompareTo(y.Priority)));
    }

    public int Count => _heap.Count;

    public void Enqueue(T item, int priority)
    {
        _heap.Add((item, priority));
    }

    public (T Item, int Priority) Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Приоритетная очередь пуста");
        }

        return _heap.Pop();
    }

    public bool TryDequeue(out (T, int) result)
    {
        if (Count == 0)
        {
            result = default;
            return false;
        }

        result = _heap.Pop();
        return true;
    }

    public (T Item, int Priority) Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Приоритетная очередь пуста");
        }

        return _heap.Peek();
    }
}