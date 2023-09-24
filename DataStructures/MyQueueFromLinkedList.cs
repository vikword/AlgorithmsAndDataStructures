namespace DataStructures;

public class MyQueueFromLinkedList<T>
{
    private readonly MyLinkedList<T> _items;
    public int Count { get; private set; }

    public bool IsEmpty => IsEmptyQueue();

    public MyQueueFromLinkedList()
    {
        _items = new MyLinkedList<T>();
    }

    private bool IsEmptyQueue()
    {
        return _items.Length == 0;
    }

    public void Enqueue(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        _items.AddLast(item);
        Count++;
    }

    public T Dequeue()
    {
        if (IsEmptyQueue())
        {
            throw new InvalidOperationException("Очередь пуста. Невозможно извлечь элемент.");
        }

        var item = _items.Head!.Data;
        _items.RemoveFirst();
        Count--;
        return item;
    }

    public bool TryDequeue(out T? result)
    {
        if (IsEmptyQueue())
        {
            result = default;
            return false;
        }

        result = _items.Head!.Data;
        _items.RemoveFirst();
        Count--;

        return true;
    }

    public T Peek()
    {
        if (IsEmptyQueue())
        {
            throw new InvalidOperationException("Очередь пуста. Невозможно извлечь элемент.");
        }

        return _items.Head!.Data;
    }

    public bool Contains(T item)
    {
        return _items.FindNode(item) != null;
    }

    public void Clear()
    {
        _items.Clear();
        Count = 0;
    }
}