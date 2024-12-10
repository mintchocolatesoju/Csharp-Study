using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue<T> where T : IComparable
{
    private List<T> heap = new List<T>();

    public void Enqueue(T item)
    {
        heap.Add(item);
        int currentIndex = heap.Count - 1;
        HeapifyUp(currentIndex);
    }

    public T Dequeue()
    {
        if(heap.Count == 0)
            throw new InvalidOperationException("Queue is empty");
        T root = heap[0];
        int lastIndex = heap.Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);

        if (heap.Count > 0)
            HeapifyDown(0);
        return root;
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex= (index - 1) / 2;
            if (heap[index].CompareTo(heap[parentIndex]) >= 0)
                break;
            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        int lastIndex = heap.Count - 1;
        while (true)
        {
            int smallest = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild <= lastIndex && heap[leftChild].CompareTo(heap[smallest]) < 0)
                smallest = leftChild;
            if (rightChild <= lastIndex && heap[rightChild].CompareTo(heap[smallest]) < 0)
                smallest = rightChild;
            if (smallest == index)
                break;
            Swap(index, smallest);
            index = smallest;
        }
    }

    private void Swap(int index1, int index2)
    {
        T temp = heap[index1];
        heap[index1] = heap[index2];
        heap[index2] = temp;
    }
    public int Count => heap.Count;
    public bool IsEmpty => heap.Count == 0;
}
