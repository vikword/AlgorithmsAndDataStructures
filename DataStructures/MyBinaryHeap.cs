namespace DataStructures;

public class MyBinaryHeap<T>
{
    private T[] _heap;
    private readonly IComparer<T> _comparer;
    public int Count { get; private set; }

    public MyBinaryHeap(int capacity = 64, IComparer<T>? comparer = null)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("Емкость должна быть положительным целым числом.");
        }

        _heap = new T[capacity];
        Count = 0;
        _comparer = comparer ?? Comparer<T>.Default;
    }

    public void Add(T item)
    {
        if (Count == _heap.Length)
        {
            Array.Resize(ref _heap, _heap.Length * 2);
        }

        _heap[Count] = item;
        SiftingUp(Count);
        Count++;
    }

    public T Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Куча пуста.");
        }

        return _heap[0];
    }

    public T Pop()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Куча пуста.");
        }

        var topItem = _heap[0];
        Count--;

        if (Count <= 0)
        {
            return topItem;
        }

        _heap[0] = _heap[Count];
        SiftingDown(0);

        return topItem;
    }

    private void SiftingUp(int index)
    {
        while (index > 0)
        {
            var parentIndex = index / 2;
            if (_comparer.Compare(_heap[index], _heap[parentIndex]) <= 0)
            {
                break;
            }

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void SiftingDown(int index)
    {
        while (true)
        {
            var leftChildIndex = 2 * index;
            var rightChildIndex = 2 * index + 1;
            var largestChildIndex = index;

            if (leftChildIndex < Count && _comparer.Compare(_heap[leftChildIndex], _heap[largestChildIndex]) > 0)
            {
                largestChildIndex = leftChildIndex;
            }

            if (rightChildIndex < Count && _comparer.Compare(_heap[rightChildIndex], _heap[largestChildIndex]) > 0)
            {
                largestChildIndex = rightChildIndex;
            }

            if (largestChildIndex == index)
            {
                break;
            }

            Swap(index, largestChildIndex);
            index = largestChildIndex;
        }
    }

    private void Swap(int i, int j)
    {
        (_heap[i], _heap[j]) = (_heap[j], _heap[i]);
    }
}