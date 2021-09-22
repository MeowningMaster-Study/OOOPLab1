using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Graph
{
    interface IEdges<Data>
    {
        public int AddVertex();
        public void RemoveVertex(int vertex);
        public void AddEdge(int vertexOne, int vertexTwo, Data data);
        public void RemoveEdge(int vertexOne, int vertexTwo);
    }
}
