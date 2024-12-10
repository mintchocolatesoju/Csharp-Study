using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBTree : MonoBehaviour
{

    private enum NodeColor
    {
        Red,
        Black
    }

    private class Node
    {
        public int data;
        public Node left, right,parent;
        public NodeColor color;

        public Node(int data)
        {
            this.data = data;
            left= right=parent=null;
            color=NodeColor.Red;
        }
    }
    
    private Node root;
    private Node NIL;
    
    
    // Start is called before the first frame update
    void Start()
    {
        NIL = new Node(0);
        NIL.color = NodeColor.Black;
        root = NIL;
    }

    private void leftRotate(Node x)
    {
        Node y = x.right;
        x.right = y.left;

        if (y.left != NIL)
            y.left.parent = x;
        y.parent= x.parent;

        if (x.parent == null)
            root = y;
        else if(x==x.parent.left)
            x.parent.left = y;
        else
            x.parent.right = y;
        y.left = x;
        x.parent = y;
    }

    private void RightRotate(Node x)
    {
        Node y = x.left;
        x.left = y.right;
        if (y.right != NIL)
        {
            y.right.parent = x;
        }
        y.parent = x.parent;
        
        if(x.parent == null)
            root = y;
        else if(x == x.parent.right)
            x.parent.right = y;
        else x.parent.left = y;
        y.right = x;
        x.parent = y;
    }

    public void Insert(int key)
    {
        Node node = new Node(key);
        node.left = NIL;
        node.right = NIL;

        Node y = null;
        Node x = root;

        while (x != NIL)
        {
            y = x;
            if (node.data < x.data)
                x = x.left;
            else
                x = x.right;
        }

        node.parent = y;

        if (y == null)
            root = node;
        else if (node.data < y.data)
            y.left = node;
        else 
            y.right = node;
        InsertFixup(node);
    }

    private void InsertFixup(Node k)
    {
        Node u;
        while (k.parent != null && k.parent.color == NodeColor.Red)
        {
            if (k.parent == k.parent.parent.right)
            {
                u = k.parent.parent.left;

                if (u.color == NodeColor.Red)
                {
                    u.color = NodeColor.Black;
                    k.parent.color = NodeColor.Black;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
