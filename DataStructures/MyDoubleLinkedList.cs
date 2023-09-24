namespace DataStructures;

public sealed class MyDoubleLinkedList<T>
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
            _head.Prev = newNode;
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
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }

        _count++;
    }

    public void AddAfter(Node<T> node, T data)
    {
        if (node == null)
        {
            throw new ArgumentNullException(nameof(node));
        }

        var newNode = new Node<T>(data)
        {
            Prev = node,
            Next = node.Next
        };

        if (node.Next != null)
        {
            node.Next.Prev = newNode;
        }

        node.Next = newNode;

        if (_tail == node)
        {
            _tail = newNode;
        }

        _count++;
    }

    public void Remove(Node<T> node)
    {
        if (node == null)
        {
            throw new ArgumentNullException(nameof(node));
        }

        if (node.Prev != null)
        {
            node.Prev.Next = node.Next;
        }
        else
        {
            _head = node.Next;
        }

        if (node.Next != null)
        {
            node.Next.Prev = node.Prev;
        }
        else
        {
            _tail = node.Prev;
        }

        _count--;
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

    public void Clear()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }
}