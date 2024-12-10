using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class StackNode<T>
{
    public T data;
    public StackNode<T> prev;
}

public class StackCustom<T> where T : new()
{
    public StackNode<T> top;

    public void Push(T data)
    {
        StackNode<T> node = new StackNode<T>();
        node.data = data; //?
        node.prev = top;
        top = node;
    }

    public T Pop()
    {
        if (top == null)
        {
            return new T();
        }
        T result = top.data;    
        top = top.prev;
        return result;
    }

    public T Peek()
    {
        if (top == null)
        {
            return new T();
        }
        return top.data;
    }
    
}

public class StackExample : MonoBehaviour
{
    [NonSerialized] // public 일지라도 인스텍터에 노출은 안되나 다른 c# class에 접근 가능
    public float speed = 5.0f; 
    
    [SerializeField]
    private float speed2 = 10.0f;
    
    private Stack<Vector3> positionStack = new Stack<Vector3>();
    private Stack<Vector3> RepositionStack = new Stack<Vector3>();
    void Start()
    {
        positionStack.Push(transform.position);
    }

    
    void Update()
    {
        Vector3 movePos = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movePos += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movePos -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movePos += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movePos -= transform.right;
        }
        
        if (Input.GetKeyDown(KeyCode.W)||
           Input.GetKeyDown(KeyCode.S)||
           Input.GetKeyDown(KeyCode.D)||
           Input.GetKeyDown(KeyCode.A))
        {
            movePos = Vector3.zero;
            positionStack.Push(transform.position);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(positionStack.Count >0)
            transform.position = positionStack.Pop();
        }
        transform.position+= movePos.normalized * (speed2 * Time.deltaTime);
        
    }

   
}

