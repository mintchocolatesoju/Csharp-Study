using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;


public class QNode<T>
{
    public T Data {get; set;}
    public QNode<T> Next {get; set;}

    public QNode(T data)
    {
        Data = data;
        Next = null;
    }
}

public class QueueCustom<T>
{
    private QNode<T> front;
    private QNode<T> back;
    private int size;

    public QueueCustom()
    {
        front = null;
        back = null;
        size = 0;
    }

    public void Enqueue(T data)
    {
        QNode<T> node = new QNode<T>(data);
        if (IsEmpty())
        {
            front = node;
            back = node;
        }
        else
        {
            back.Next = node;
            back = node;
        }
        size++; 
    }

    public T Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        T data = front.Data;
        front = front.Next;
        size--;
        if (IsEmpty())
        {
            back = null;
            
        }
        return data;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return front.Data;
    }

    public int Size()
    {
        return size;
    }
    
    public bool IsEmpty()
    {
        return size == 0;
    }
}


public class QueueExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
