using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Libraries.Graph.Edges
{
    public interface IEdges<TData>
    {
        public int AddVertex();
        public void RemoveVertex(int vertex);
        public void Add(int vertexOne, int vertexTwo, TData data);
        public void Remove(int vertexOne, int vertexTwo);
        public IEnumerable<(int, TData)> GetVertexEdgesEnumerator(int vertex);
        public (bool, TData) Get(int vertexOne, int vertexTwo);
    }
}
