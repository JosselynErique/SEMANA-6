using System;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; } // Permitir valores null

    public Node(T data)
    {
        Data = data;
        Next = null; // Inicialización explícita
    }
}

public class LinkedList<T>
{
    private Node<T>? head; // Permitir valores null

    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node<T>? current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void PrintList()
    {
        Node<T>? current = head;
        while (current != null)
        {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    public void Reverse()
    {
        Node<T>? prev = null;
        Node<T>? current = head;
        Node<T>? next = null;

        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }

        head = prev;
    }
}

class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);

        Console.WriteLine("Lista original:");
        list.PrintList();

        list.Reverse();

        Console.WriteLine("Lista invertida:");
        list.PrintList();
    }
}

