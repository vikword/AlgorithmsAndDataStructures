namespace DataStructures;

public class MyStackFromLinkedList<T>
{
    private readonly MyLinkedList<T> _items;

    public int Count => _items.Length;
    public bool IsEmpty => Empty();

    public MyStackFromLinkedList()
    {
        _items = new MyLinkedList<T>();
    }

    public void Push(T item)
    {
        _items.AddFirst(item);
    }

    public T Peek()
    {
        if (Empty())
        {
            throw new InvalidOperationException("Стек пуст");
        }

        return _items.Head!.Data;
    }

    public T Pop()
    {
        if (Empty())
        {
            throw new InvalidOperationException("Стек пуст");
        }

        var item = _items.Head;
        _items.RemoveFirst();
        return item!.Data;
    }

    private bool Empty()
    {
        return _items.Length == 0;
    }
}