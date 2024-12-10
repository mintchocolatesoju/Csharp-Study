using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Graph : MonoBehaviour
{
   public class Vertex
    {
        public string name;
        public Dictionary<Vertex, float> neighbors = new Dictionary<Vertex, float>();

        public Vertex(string name)
        {
            this.name = name;
        }
    }
    
    private Dictionary<string, Vertex> vertices = new Dictionary<string, Vertex>();

    public void AddVertex(string name)
    {
        if (!vertices.ContainsKey(name))
        {
            vertices.Add(name, new Vertex(name));
        }
    }
    
    public void AddEdge(string from, string to, float weight)
    {
        if (vertices.ContainsKey(from) && vertices.ContainsKey(to))
        {
            Vertex fromV = vertices[from];
            Vertex toV = vertices[to];

            if (!fromV.neighbors.ContainsKey(toV))
            {
                fromV.neighbors.Add(toV, weight);
            }
        }
    }

    public void BFS(string startName)
    {
        if (!vertices.ContainsKey(startName))
            return;
        
        HashSet<Vertex> visited = new HashSet<Vertex>();
        Queue<Vertex> queue = new Queue<Vertex>();
        
        Vertex startVertex = vertices[startName];
        queue.Enqueue(startVertex);
        visited.Add(startVertex);

        while (queue.Count > 0)
        {
            Vertex currentVertex = queue.Dequeue();
            Debug.Log($"방문 {currentVertex.name}");

            foreach (var neightbor in currentVertex.neighbors.Keys)
            {
                if (!visited.Contains(neightbor))
                {
                    visited.Add(neightbor);
                    queue.Enqueue(neightbor);
                }
            }
        }
    }

    public void DFS(string startName)
    {
        if (!vertices.ContainsKey(startName))
            return;
        
        HashSet<Vertex> visited = new HashSet<Vertex>();
        DFSUtil(vertices[startName], visited);
    }

    public void DFSUtil(Vertex vertex, HashSet<Vertex> visited)
    {
        visited.Add(vertex);
        Debug.Log($"방문 {vertex.name}");

        foreach (var neighbor in vertex.neighbors.Keys)
        {
            if (!visited.Contains(neighbor))
            {
                DFSUtil(neighbor, visited);
            }
        }
    }

    public void Dijkstra(string startName)
    {
        if(!vertices.ContainsKey(startName))
            return;
        Dictionary<Vertex, float> distances = new Dictionary<Vertex, float>();
        Dictionary<Vertex, Vertex> previous = new Dictionary<Vertex, Vertex>();
        HashSet<Vertex> unvisited = new HashSet<Vertex>();

        foreach (var vertex in vertices.Values)
        {
            distances[vertex] = float.MaxValue;
            previous[vertex] = null;
            unvisited.Add(vertex);
        }

        Vertex start = vertices[startName];
        distances[start] = 0;

        while (unvisited.Count > 0)
        {
            // 가장 가까운 미방문 정점 찾기
            Vertex current = null;
            float minDistance = float.MaxValue;
            foreach (var vertex in unvisited)
            {
                if (distances[vertex] < minDistance)
                {
                    current = vertex;
                    minDistance = distances[vertex];
                }
            }

            if (current == null) break;

            unvisited.Remove(current);

            foreach (var neighbor in current.neighbors)
            {
                float alt = distances[current] + neighbor.Value;
                if (alt < distances[neighbor.Key])
                {
                    distances[neighbor.Key] = alt;
                    previous[neighbor.Key] = current;
                }
            }
        }

        
        foreach (var vertex in vertices.Values)
        {
            Debug.Log($"{startName}에서 {vertex.name}까지의 최단 거리: {distances[vertex]}");
        }
    }

    
    
    // Start is called before the first frame update
    void Start()
    {
        AddVertex("집");
        AddVertex("슈퍼마켓");
        AddVertex("미용실");
        AddVertex("은행");
        AddVertex("영어학원");
        AddVertex("학교");
        
        AddEdge("집", "미용실", 5.0f);
        AddEdge("집", "슈퍼마켓", 10.0f);
        AddEdge("집", "영어학원", 9.0f);
        AddEdge("미용실", "슈퍼마켓", 3.0f);
        AddEdge("미용실", "은행", 11.0f);
        AddEdge("슈퍼마켓", "레스토랑", 3.0f);
        AddEdge("슈퍼마켓", "은행", 10.0f);
        AddEdge("슈퍼마켓", "영어학원", 7.0f);
        AddEdge("레스토랑", "은행", 4.0f);
        AddEdge("은행", "학교", 2.0f);
        AddEdge("은행", "영어학원", 7.0f);
        AddEdge("영어학원", "학교", 12.0f);
        
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
