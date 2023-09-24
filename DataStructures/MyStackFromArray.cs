namespace DataStructures;

public class MyStackFromArray<T>
{
    private readonly T[] _items;
    private int _top = -1;
    public int Count => _top + 1;
    public bool IsEmpty => Empty();

    public MyStackFromArray()
    {
        _items = new T[32];
    }

    public MyStackFromArray(int capacity)
    {
        _items = new T[capacity];
    }

    public void Push(T item)
    {
        if (Fool())
        {
            throw new InvalidOperationException("Стек переполнен");
        }

        _items[++_top] = item;
    }

    public T Peek()
    {
        if (Empty())
        {
            throw new InvalidOperationException("Стек пуст");
        }

        return _items[_top];
    }

    public T Pop()
    {
        if (Empty())
        {
            throw new InvalidOperationException("Стек пуст");
        }

        return _items[_top--];
    }

    private bool Empty()
    {
        return _top == -1;
    }

    private bool Fool()
    {
        return _top == _items.Length - 1;
    }

    public void Clear()
    {
        Array.Clear(_items, 0, _items.Length);
        _top = -1;
    }
}