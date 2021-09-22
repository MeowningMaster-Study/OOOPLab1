using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Graph
{
    public class AdjacencyListConnections<T> : Connections<T>
    {
        private List<Dictionary<int, T>> storage;

        public AdjacencyListConnections()
        {
            this.storage = new List<Dictionary<int, T>>();
        }

        public void AddEdge(int vertexOne, int vertexTwo, T data)
        {
            storage[vertexOne].Add(vertexTwo, data);
            storage[vertexTwo].Add(vertexOne, data);
        }

        public int AddVertex()
        {
            storage.Add(new Dictionary<int, T>());
            return storage.Count - 1;
        }

        public void RemoveEdge(int vertexOne, int vertexTwo)
        {
            _ = storage[vertexOne].Remove(vertexTwo);
            _ = storage[vertexTwo].Remove(vertexOne);
        }

        public void RemoveVertex(int vertex)
        {
            foreach (int i in storage[vertex].Keys)
            {
                _ = storage[i].Remove(vertex);
            }
            storage.RemoveAt(vertex);
        }
    }
}
