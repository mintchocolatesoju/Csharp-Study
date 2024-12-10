using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class StackNode2<T>
{
   public T data;
   public StackNode2<T> prev;
}

public class StackCustom2<T> where T : new()
{
   public StackNode2<T> top;

   public void Push(T data)
   {
      StackNode2<T> node = new StackNode2<T>();
      node.data = data;
      node.prev = top;
      top = node;
   }

   public T Pop()
   {
      if (top == null)
      {
         return new T();
      }
      T data = top.data;
      top = top.prev;
      return data;
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


public class StackUnRedo : MonoBehaviour
{
   private float speed = 10.0f;   
   
   private Stack<Vector3> positionStack = new Stack<Vector3>();
   private Stack<Vector3> RepositonStack = new Stack<Vector3>();
   
   // 이동

   void Start()
   {
         
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
         RepositonStack.Clear();
      }

      if (Input.GetKeyDown(KeyCode.Space))
      {
         if (positionStack.Count > 0)
         {
            transform.position = positionStack.Pop();
            RepositonStack.Push(transform.position);
         }
      }
      if(Input.GetKeyDown(KeyCode.Z))
      {
         if (RepositonStack.Count > 0)
         {
            transform.position = RepositonStack.Pop();
            positionStack.Push(transform.position);
         }
      }
      transform.position += movePos * (speed * Time.deltaTime);
      
   }
}
