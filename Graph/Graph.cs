using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Graph
{
    class Graph<TVertexData, TConnectionData>
    {
        private readonly List<Vertex<TVertexData>> vertices;
        private readonly Connections<TConnectionData> connections;

        public Graph()
        {
            this.vertices = new List<Vertex<TVertexData>>();
            this.connections = new AdjacencyListConnections<TConnectionData>();
        }

        public int AddVertex(TVertexData data)
        {
            vertices.Add(new Vertex<TVertexData>(data));
            return connections.AddVertex();
        }

        public void RemoveVertex(int index)
        {
            vertices.RemoveAt(index);
            connections.RemoveVertex(index);
        }
    }
}
