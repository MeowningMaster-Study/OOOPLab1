using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Graph.Edges
{
    public class AdjacencyList<TData> : IEdges<TData>
    {
        private readonly List<Dictionary<int, TData>> storage;

        public AdjacencyList()
        {
            storage = new List<Dictionary<int, TData>>();
        }

        public void Add(int vertexOne, int vertexTwo, TData data)
        {
            storage[vertexOne].Add(vertexTwo, data);
            storage[vertexTwo].Add(vertexOne, data);
        }

        public int AddVertex()
        {
            storage.Add(new Dictionary<int, TData>());
            return storage.Count - 1;
        }

        public (bool, TData) Get(int vertexOne, int vertexTwo)
        {
            return (storage[vertexOne].TryGetValue(vertexTwo, out TData value), value);
        }

        public IEnumerable<(int, TData)> GetVertexEdgesEnumerator(int vertex)
        {
            foreach (KeyValuePair<int, TData> i in storage[vertex])
            {
                yield return (i.Key, i.Value);
            }
        }

        public void Remove(int vertexOne, int vertexTwo)
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
