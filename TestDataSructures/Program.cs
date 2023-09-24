using System.Diagnostics;
using DataStructures;

namespace TestDataSructures;

class Program
{
    static void Main()
    {
        const int numElements = 1000000; // Размер очереди
        var str = "test My Data Structure";

        var queue = new Queue<string>(numElements);

        var queueFromArray = new MyQueueFromArray<string>(numElements);

        var queueFromLinkedList = new MyQueueFromLinkedList<string>();

        var queueFromDoubleStack = new MyQueueFromDoubleStack<string>(numElements);

        var myPriorityQueue = new MyPriorityQueue<string>(numElements);

        var priorityQueue = new PriorityQueue<string, int>(numElements);

        var myDoubleLinkedList = new MyDoubleLinkedList<string>();

        var myLinkedList = new MyLinkedList<string>();

        var linkedList = new LinkedList<string>();

        var stackFromArray = new MyStackFromArray<string>(numElements);

        var stackFromLinkedList = new MyStackFromLinkedList<string>();

        // Замер времени и потребления памяти для Queue<T>
        MeasurePerformance("Queue<T>", () =>
        {
            for (var i = 0; i < numElements; i++)
            {
                queue.Enqueue(str);
            }

            while (queue.TryDequeue(out _))
            {
            }
        });

        // Замер времени и потребления памяти для MyQueueFromArray<T>
        MeasurePerformance("MyQueueFromArray<T>", () =>
        {
            for (var i = 0; i < numElements; i++)
            {
                queueFromArray.Enqueue(str);
            }

            while (queueFromArray.TryDequeue(out _))
            {
            }
        });

        // Замер времени и потребления памяти для MyQueueFromLinkedList<T>
        MeasurePerformance("MyQueueFromLinkedList<T>", () =>
        {
            for (var i = 0; i < numElements; i++)
            {
                queueFromLinkedList.Enqueue(str);
            }

            while (queueFromLinkedList.TryDequeue(out _))
            {
            }
        });

        // Замер времени и потребления памяти для MyQueueFromDoubleStack<T>
        MeasurePerformance("MyQueueFromDoubleStack<T>", () =>
        {
            for (var i = 0; i < numElements; i++)
            {
                queueFromDoubleStack.Enqueue(str);
            }

            while (queueFromDoubleStack.TryDequeue(out _))
            {
            }
        });
        
        // Замер времени и потребления памяти для MyPriotityQueue<T>
        MeasurePerformance("MyPriotityQueue<T>", () =>
        {
            for (var i = 0; i < numElements; i++)
            {
                myPriorityQueue.Enqueue(str, i);
            }

            while (myPriorityQueue.TryDequeue(out _))
            {
            }
        });

        // Замер времени и потребления памяти для PriotityQueue<T>
        MeasurePerformance("PriotityQueue<T>", () =>
        {
            for (var i = 0; i < numElements; i++)
            {
                priorityQueue.Enqueue(str, i);
            }

            while (priorityQueue.TryDequeue(out _, out _))
            {
            }
        });

        // Замер времени и потребления памяти для MyStackFromArray<T>
        MeasurePerformance("MyStackFromArray<T>", () =>
        {
            for (var i = 0; i < numElements; i++)
            {
                stackFromArray.Push(str);
            }

            for (var i = 0; i < numElements; i++)
            {
                stackFromArray.Pop();
            }
        });

        // Замер времени и потребления памяти для MyStackFromLinkedList<T>
        MeasurePerformance("MyStackFromLinkedList<T>", () =>
        {
            for (var i = 0; i < numElements; i++)
            {
                stackFromLinkedList.Push(str);
            }

            for (var i = 0; i < numElements; i++)
            {
                stackFromLinkedList.Pop();
            }
        });

        // Замер времени и потребления памяти для MyLinkedList<T>
        MeasurePerformance("MyLinkedList<T>", () =>
        {
            for (var i = 0; i < numElements; i++)
            {
                myLinkedList.AddLast(str);
            }

            for (var i = 0; i < numElements; i++)
            {
                myLinkedList.RemoveFirst();
            }
        });

        // Замер времени и потребления памяти для MyDoubleLinkedList<T>
        MeasurePerformance("MyDoubleLinkedList<T>", () =>
        {
            for (var i = 0; i < numElements; i++)
            {
                myDoubleLinkedList.AddLast(str);
            }

            for (var i = 0; i < numElements; i++)
            {
                myDoubleLinkedList.Remove(new Node<string>(str));
            }
        });

        // Замер времени и потребления памяти для LinkedList<T>
        MeasurePerformance("LinkedList<T>", () =>
        {
            for (var i = 0; i < numElements; i++)
            {
                linkedList.AddLast(str);
            }

            for (var i = 0; i < numElements; i++)
            {
                linkedList.RemoveFirst();
            }
        });
    }

    static void MeasurePerformance(string queueType, Action action)
    {
        var stopwatch = Stopwatch.StartNew();
        var startMemory = GC.GetTotalMemory(true);

        action();

        var endMemory = GC.GetTotalMemory(true);
        stopwatch.Stop();

        Console.WriteLine($"{queueType} performance:");
        Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine($"Memory Usage: {endMemory - startMemory} Byte");
        Console.WriteLine(new string('-', 78));
    }
}