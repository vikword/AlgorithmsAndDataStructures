using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using DataStructures;

namespace TestMemoryAndSpeed;

class Program
{
    static void Main()
    {
        var summary = BenchmarkRunner.Run<Capacity>();
    }
}

[MemoryDiagnoser]
public class Capacity
{
    [Params(1_000, 10_000, 100_000, 1_000_000, 10_000_000)]
    public int NumberCount;

    private string str = "Hello World";

    [Benchmark]
    public void Queue_Capacity()
    {
        Queue<string> items = new(NumberCount);
        for (var i = 0; i < NumberCount; i++)
        {
            items.Enqueue(str);
        }

        while (items.TryDequeue(out _))
        {
        }
    }

    [Benchmark]
    public void MyQueueFromArray_Capacity()
    {
        MyQueueFromArray<string> items = new(NumberCount);
        for (int i = 0; i < NumberCount; i++)
        {
            items.Enqueue(str);
        }

        while (items.TryDequeue(out _))
        {
        }

        items.Dispose();
    }

    [Benchmark]
    public void MyQueueFromLinkedList_Capacity()
    {
        MyQueueFromLinkedList<int> items = new();
        for (int i = 0; i < NumberCount; i++)
        {
            items.Enqueue(i);
        }

        while (items.TryDequeue(out _))
        {
        }
    }

    [Benchmark]
    public void MyQueueFromDoubleStack_Capacity()
    {
        MyQueueFromDoubleStack<int> items = new(NumberCount);
        for (int i = 0; i < NumberCount; i++)
        {
            items.Enqueue(i);
        }

        while (items.TryDequeue(out _))
        {
        }
    }

    [Benchmark]
    public void PriorityQueue_Capacity()
    {
        var random = new Random();
        PriorityQueue<int, int> items = new(NumberCount);
        for (int i = 0; i < NumberCount; i++)
        {
            items.Enqueue(i, random.Next(0, 1000));
        }

        while (items.TryDequeue(out _, out _))
        {
        }
    }

    [Benchmark]
    public void MyPriorityQueue_Capacity()
    {
        var random = new Random();
        MyPriorityQueue<int> items = new(NumberCount);
        for (int i = 0; i < NumberCount; i++)
        {
            items.Enqueue(i, random.Next(0, 1000));
        }

        while (items.TryDequeue(out _))
        {
        }
    }

    [Benchmark]
    public void Stack_Capacity()
    {
        Stack<int> items = new(NumberCount);
        for (int i = 0; i < NumberCount; i++)
        {
            items.Push(i);
        }

        for (int i = 0; i < NumberCount; i++)
        {
            items.Pop();
        }
    }

    [Benchmark]
    public void MyStackFromArray_Capacity()
    {
        MyStackFromArray<int> items = new(NumberCount);
        for (int i = 0; i < NumberCount; i++)
        {
            items.Push(i);
        }

        for (int i = 0; i < NumberCount; i++)
        {
            items.Pop();
        }
    }

    [Benchmark]
    public void MyStackFromLinkedList_Capacity()
    {
        MyStackFromLinkedList<int> items = new();
        for (int i = 0; i < NumberCount; i++)
        {
            items.Push(i);
        }

        for (int i = 0; i < NumberCount; i++)
        {
            items.Pop();
        }
    }

    [Benchmark]
    public void LinkedList_Capacity()
    {
        LinkedList<int> items = new();
        for (int i = 0; i < NumberCount; i++)
        {
            items.AddLast(i);
        }

        for (int i = 0; i < NumberCount; i++)
        {
            items.Remove(i);
        }
    }

    [Benchmark]
    public void MyLinkedList_Capacity()
    {
        MyLinkedList<int> items = new();
        for (int i = 0; i < NumberCount; i++)
        {
            items.AddLast(i);
        }

        for (int i = 0; i < NumberCount; i++)
        {
            items.RemoveFirst();
        }
    }

    [Benchmark]
    public void MyDoubleLinkedList_Capacity()
    {
        MyDoubleLinkedList<int> items = new();
        for (int i = 0; i < NumberCount; i++)
        {
            items.AddLast(i);
        }

        for (int i = 0; i < NumberCount; i++)
        {
            items.Remove(new Node<int>(i));
        }
    }
}