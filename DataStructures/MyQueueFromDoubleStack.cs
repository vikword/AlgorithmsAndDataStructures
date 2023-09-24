namespace DataStructures;

public class MyQueueFromDoubleStack<T>
{
    private readonly MyStackFromArray<T> _enqueueStack;
    private readonly MyStackFromArray<T> _dequeueStack;

    public MyQueueFromDoubleStack(int capacity)
    {
        _enqueueStack = new MyStackFromArray<T>(capacity);
        _dequeueStack = new MyStackFromArray<T>(capacity);
    }

    public bool IsEmpty => IsEmptyQueue();

    public void Enqueue(T item)
    {
        _enqueueStack.Push(item);
    }

    public T Dequeue()
    {
        if (IsEmptyQueue())
        {
            throw new InvalidOperationException("Очередь пустая.");
        }

        if (_dequeueStack.Count != 0)
        {
            return _dequeueStack.Pop();
        }

        while (_enqueueStack.Count > 0)
        {
            _dequeueStack.Push(_enqueueStack.Pop());
        }

        return _dequeueStack.Pop();
    }

    public bool TryDequeue(out T? result)
    {
        if (IsEmptyQueue())
        {
            result = default;
            return false;
        }

        if (_dequeueStack.Count != 0)
        {
            result = _dequeueStack.Pop();
            return true;
        }

        while (_enqueueStack.Count > 0)
        {
            _dequeueStack.Push(_enqueueStack.Pop());
        }

        result = _dequeueStack.Pop();
        return true;
    }

    public T Peek()
    {
        if (IsEmptyQueue())
        {
            throw new InvalidOperationException("Очередь пустая.");
        }

        if (_dequeueStack.Count != 0)
        {
            return _dequeueStack.Peek();
        }

        while (_enqueueStack.Count > 0)
        {
            _dequeueStack.Push(_enqueueStack.Pop());
        }

        return _dequeueStack.Peek();
    }

    private bool IsEmptyQueue()
    {
        return _enqueueStack.Count == 0 && _dequeueStack.Count == 0;
    }

    public int Count()
    {
        return _enqueueStack.Count + _dequeueStack.Count;
    }

    public void Clear()
    {
        _dequeueStack.Clear();
        _enqueueStack.Clear();
    }
}