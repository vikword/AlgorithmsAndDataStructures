using System.Buffers;

namespace DataStructures;

public sealed class MyQueueFromArray<T> : IDisposable
{
    private T[] _items;
    private int _head;
    private int _tail;
    private int _size;
    private readonly int _capacity;

    public MyQueueFromArray()
    {
        _items = ArrayPool<T>.Shared.Rent(0);
    }

    public MyQueueFromArray(int capacity)
    {
        _capacity = capacity;
        _items = ArrayPool<T>.Shared.Rent(capacity);
        _head = 0;
        _tail = 0;
        _size = 0;
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    public bool IsFull()
    {
        return _size == _capacity;
    }

    public int Size()
    {
        return _size;
    }

    public void Enqueue(T item)
    {
        // if (IsFull())
        // {
        //     throw new InvalidOperationException("Очередь переполнена. Невозможно добавить элемент.");
        // }
        if (_size == _items.Length)
        {
            Grow(_size + 1);
        }

        _items[_tail] = item;
        MoveNext(ref _tail);
        _size++;
    }

    public T Dequeue()
    {
        var head = _head;
        var array = _items;

        if (IsEmpty())
        {
            throw new InvalidOperationException("Очередь пуста. Невозможно извлечь элемент.");
        }

        var removed = array[head];

        array[head] = default!;

        MoveNext(ref _head);
        _size--;
        return removed;
    }

    public bool TryDequeue(out T? result)
    {
        var head = _head;
        var array = _items;

        if (IsEmpty())
        {
            result = default;
            return false;
        }

        result = array[head];

        array[head] = default!;

        MoveNext(ref _head);
        _size--;
        return true;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Очередь пуста. Невозможно извлечь элемент.");
        }

        return _items[_head];
    }

    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public void Clear()
    {
        Array.Clear(_items, 0, _capacity);
        _head = 0;
        _tail = 0;
        _size = 0;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~MyQueueFromArray()
    {
        Dispose(false);
    }

    private void Dispose(bool disposing)
    {
        ArrayPool<T>.Shared.Return(_items);
        _items = default!;
    }

    private void MoveNext(ref int index)
    {
        var tmp = index + 1;
        if (tmp == _capacity)
        {
            tmp = 0;
        }

        index = tmp;
    }

    private void SetCapacity(int capacity)
    {
        var newArray = ArrayPool<T>.Shared.Rent(capacity);
        if (_size > 0)
        {
            if (_head < _tail)
            {
                Array.Copy(_items, _head, newArray, 0, _size);
            }
            else
            {
                Array.Copy(_items, _head, newArray, 0, _capacity - _head);
                Array.Copy(_items, 0, newArray, _capacity - _head, _tail);
            }
        }
        
        _items = newArray;
        _head = 0;
        _tail = (_size == capacity) ? 0 : _size;
    }
    
    private void Grow(int capacity)
    {
        const int growFactor = 2;
        const int minimumGrow = 4;

        var newCapacity = growFactor * _items.Length;

        if ((uint)newCapacity > Array.MaxLength)
        {
            newCapacity = Array.MaxLength;
        }

        newCapacity = Math.Max(newCapacity, _items.Length + minimumGrow);

        if (newCapacity < capacity)
        {
            newCapacity = capacity;
        }

        SetCapacity(newCapacity);
    }
}