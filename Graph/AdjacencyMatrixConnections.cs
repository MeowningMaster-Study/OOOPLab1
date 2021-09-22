using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Graph
{
    public class AdjacencyMatrixConnections<TData> : Connections<TData>
    {
        private readonly List<List<(bool, TData)>> Storage;

        public void AddEdge(int vertexOne, int vertexTwo, TData data)
        {
            Storage[vertexOne][vertexTwo] = (true, data);
            Storage[vertexTwo][vertexOne] = (true, data);
        }

        public int AddVertex()
        {
            int count = Storage.Count;
            Storage.Add(new List<(bool, TData)>(count));
            return count;
        }

        public void RemoveEdge(int vertexOne, int vertexTwo)
        {
            Storage[vertexOne][vertexTwo] = (false, default(TData));
            Storage[vertexTwo][vertexOne] = (false, default(TData));
        }

        public void RemoveVertex(int vertex)
        {
            foreach (int i in Enumerable.Range(0, Storage.Count))
            {
                Storage[i].RemoveAt(vertex);
            }
            Storage.RemoveAt(vertex);
        }
    }
}
