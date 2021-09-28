using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Graph.Edges
{
    public class AdjacencyMatrix<TData> : IEdges<TData>
    {
        private readonly List<List<(bool, TData)>> storage;

        public AdjacencyMatrix()
        {
            storage = new List<List<(bool, TData)>>();
        }

        public void Add(int vertexOne, int vertexTwo, TData data)
        {
            storage[vertexOne][vertexTwo] = (true, data);
            storage[vertexTwo][vertexOne] = (true, data);
        }

        public int AddVertex()
        {
            int count = storage.Count;
            storage.Add(new List<(bool, TData)>(Enumerable.Repeat((false, default(TData)), count)));
            foreach (int i in Enumerable.Range(0, storage.Count))
            {
                storage[i].Add((false, default(TData)));
            }
            return count;
        }

        public (bool, TData) Get(int vertexOne, int vertexTwo)
        {
            return storage[vertexOne][vertexTwo];
        }

        public IEnumerable<(int, TData)> GetVertexEdgesEnumerator(int vertex)
        {
            for (int i = 0; i < storage[vertex].Count; i += 1)
            {
                if (storage[vertex][i].Item1)
                {
                    yield return (i, storage[vertex][i].Item2);
                }
            }
        }

        public void Remove(int vertexOne, int vertexTwo)
        {
            storage[vertexOne][vertexTwo] = (false, default);
            storage[vertexTwo][vertexOne] = (false, default);
        }

        public void RemoveVertex(int vertex)
        {
            foreach (int i in Enumerable.Range(0, storage.Count))
            {
                storage[i].RemoveAt(vertex);
            }
            storage.RemoveAt(vertex);
        }
    }
}
