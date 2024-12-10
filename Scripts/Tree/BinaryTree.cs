using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTree : MonoBehaviour
{
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int data)
        {
            Data = data;
            Left = Right = null;
        }
    }
    
    private Node root;

    public void PreOrder(Node node)
    {
        if (node == null)
            return;
        Debug.Log(node.Data);
        PreOrder(node.Left);
        PreOrder(node.Right);
    }

    public void InOrder(Node node)
    {
        if (node == null)
            return;
        InOrder(node.Left);
        Debug.Log(node.Data);
        InOrder(node.Right);
    }

    public void PostOrder(Node node)
    {
        if (node == null)
            return;
        PostOrder(node.Left);
        PostOrder(node.Right);
        Debug.Log(node.Data);
    }

    private void Start()
    {
        Node root = new Node(100);
        root.Left = new Node(50);
        root.Left.Left = new Node(30);
        root.Left.Right = new Node(40);
        root.Right = new Node(120);
        root.Right.Left = new Node(110);
        root.Right.Right = new Node(150);
        
        PreOrder(root);
        
       // InOrder(root);
        //PostOrder(root);
        Debug.Log("Binary Tree");
       
    }
}
