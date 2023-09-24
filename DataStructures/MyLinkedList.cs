namespace DataStructures;

public sealed class MyLinkedList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;
    private int _count;

    public Node<T>? Head => _head;
    public Node<T>? Tail => _tail;
    public int Length => _count;

    public void AddFirst(T data)
    {
        var newNode = new Node<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head = newNode;
        }

        _count++;
    }

    public void AddLast(T data)
    {
        var newNode = new Node<T>(data);
        if (_tail == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            _tail = newNode;
        }

        _count++;
    }

    public void AddAfter(Node<T> prevNode, T data)
    {
        if (prevNode == null)
        {
            throw new ArgumentNullException(nameof(prevNode), "Предыдущий узел не может быть null");
        }

        var newNode = new Node<T>(data)
        {
            Next = prevNode.Next
        };
        prevNode.Next = newNode;
        if (prevNode == _tail)
        {
            _tail = newNode;
        }

        _count++;
    }

    public Node<T>? FindNode(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Data, data))
            {
                return current;
            }

            current = current.Next;
        }

        return null;
    }

    public void RemoveFirst()
    {
        if (_head == null)
        {
            return;
        }

        _head = _head.Next;
        _count--;
        if (_count == 0)
        {
            _tail = null;
        }
    }

    public void RemoveAfter(Node<T> prevNode)
    {
        if (prevNode == null)
        {
            throw new ArgumentNullException(nameof(prevNode), "Предыдущий узел не может быть null");
        }

        if (prevNode.Next == null)
        {
            return;
        }

        prevNode.Next = prevNode.Next.Next;
        if (prevNode.Next == null)
        {
            _tail = prevNode;
        }

        _count--;
    }

    public void Clear()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }
}