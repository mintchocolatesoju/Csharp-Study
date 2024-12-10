using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;


public class DNode<T>
{
    public T Data { get; set; }
    public DNode<T> Next { get; set; }
    public DNode<T> Prev { get; set; }
    
    
    public DNode(T data)
    {
        Data = data;
        Prev = null;
        Next = null;
    }
}

public class DLinkedListCustom<T>
{
    public DNode<T> Head {get; private set;}
    public DNode<T> Tail {get; private set;}

    private int count;

    public void AddLast(T data)
    {
        DNode<T> newnode = new DNode<T>(data);
        if(Head == null)
        {
            Head = newnode;
            Tail = newnode;
        }
        else
        {
            newnode.Prev = Tail;
            Tail = newnode;
            Tail.Next = null;
            
        }
    }

    public void AddFirst(T data)
    {
        DNode<T> node = new DNode<T>(data);
        if (Head == null)
        {
            Head = node;
            Tail = node;
        }
       
        else
        {
            Head.Prev = node;
            node.Next = Head;
            Head = node;
        }
    }

    public void RemoveLast(T data)
    {
        DNode<T> current = Tail;
        current.Prev = Tail;
        Tail.Next = null;


    }

    public void RemoveFirst(T data)
    {
        DNode<T> current = Head;
        current.Next = Head;
        Head.Prev = null;
    }

    public void Insert(T data, int index)
    {
        DNode<T> newNode = new DNode<T>(data);
        if (index < 0 || index > count)
        {
            return;
        }
        if (index == 0)
        {
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
       
            else
            {
                Head.Prev = newNode;
                newNode.Next = Head;
                Head = newNode;
            }
        }
        else if (index == count)
        {
            if(Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Prev = Tail;
                Tail = newNode;
                Tail.Next = null;
            }
        }
        else // 중간 위치에 삽입
        {
            DNode<T> current = Head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            newNode.Prev = current;

            if (current.Next != null)
            {
                current.Next.Prev = newNode;
            }

            current.Next = newNode;
        }

        count++;
    }
        
    
    public void Traverse()
    {
        DNode<T> current = Head;
        while (current != null)
        {
            Debug.Log(current.Data);
            current = current.Next;
        }
    }
    
}
public partial class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

public class LinkedListCustom<T>
{
    public Node<T> Head { get; private set; }

    public void AddLast(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    public void AddFirst(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if(Head == null)
            Head = newNode;
        else
        {
            Node<T> next = Head;
            Head = newNode;
            
        }
    }

    public void RemoveFirst(T data)
    {
        Node<T> current = Head;
        if (current.Next != null)
        {
            current.Next = Head;
        }
        
    }

    
    
    public void Traverse()
    {
        Node<T> current = Head;
        while (current != null)
        {
            Debug.Log(current.Data);
            current = current.Next;
        }
    }
}


public class ListExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       /* LinkedList<int> list = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);
        list.AddFirst(0);
        
        var enumerator = list.GetEnumerator();

        int findIndex = 3;
        int CurrentIndex = 0;

        while (enumerator.MoveNext())
        {
            if (CurrentIndex == findIndex)
            {
                Debug.Log(enumerator.Current);
                break;
            }
            
            CurrentIndex++;
        }
        */
        LinkedListCustom<int> list = new LinkedListCustom<int>();
        list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);
        list.AddFirst(4);

        list.Traverse();
    }
    
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
