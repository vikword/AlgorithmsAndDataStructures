namespace DataStructures;

public class MyQueueFromArray<T>
{
    private readonly T[] _items;
    private int _front;
    private int _rear;
    private int _size;
    private readonly int _capacity;

    public MyQueueFromArray(int capacity)
    {
        _capacity = capacity;
        _items = new T[capacity];
        _front = 0;
        _rear = -1;
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
        if (IsFull())
        {
            throw new InvalidOperationException("Очередь переполнена. Невозможно добавить элемент.");
        }

        _rear = (_rear + 1) % _capacity;
        _items[_rear] = item;
        _size++;
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Очередь пуста. Невозможно извлечь элемент.");
        }

        var item = _items[_front];
        _front = (_front + 1) % _capacity;
        _size--;
        return item;
    }

    public bool TryDequeue(out T? result)
    {
        if (IsEmpty())
        {
            result = default;
            return false;
        }

        result = _items[_front];
        _front = (_front + 1) % _capacity;
        _size--;

        return true;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Очередь пуста. Невозможно извлечь элемент.");
        }

        return _items[_front];
    }

    public bool Contains(T item)
    {
        return _items.Contains(item);
    }

    public void Clear()
    {
        Array.Clear(_items, 0, _items.Length);
        _front = 0;
        _rear = -1;
        _size = 0;
    }
}