using System;

public class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedList<T>
{
    private Node<T>? head;

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

    public void RemoveOutOfRange(int lowerBound, int upperBound)
    {
        // Eliminar nodos fuera del rango
        while (head != null && (Convert.ToInt32(head.Data) < lowerBound || Convert.ToInt32(head.Data) > upperBound))
        {
            head = head.Next;
        }

        Node<T>? current = head;
        while (current?.Next != null)
        {
            if (Convert.ToInt32(current.Next.Data) < lowerBound || Convert.ToInt32(current.Next.Data) > upperBound)
            {
                current.Next = current.Next.Next;
            }
            else
            {
                current = current.Next;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        LinkedList<int> list = new LinkedList<int>();
        Random random = new Random();

        // Crear la lista enlazada con 50 números aleatorios entre 1 y 999
        for (int i = 0; i < 50; i++)
        {
            list.Add(random.Next(1, 1000));
        }

        Console.WriteLine("Lista original:");
        list.PrintList();

        // Leer el rango de valores desde el teclado
        Console.Write("Ingrese el límite inferior del rango: ");
        int lowerBound = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ingrese el límite superior del rango: ");
        int upperBound = int.Parse(Console.ReadLine() ?? "0");

        // Filtrar los nodos fuera del rango
        list.RemoveOutOfRange(lowerBound, upperBound);

        Console.WriteLine("\nLista después de eliminar nodos fuera del rango:");
        list.PrintList();
    }
}
