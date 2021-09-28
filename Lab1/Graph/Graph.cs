using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Graph
{
    public class Graph<TEdges, TVertexData, TEdgeData> where TEdges : Edges.IEdges<TEdgeData>, new()
    {
        public readonly Vertices<TVertexData> vertices;
        public readonly Edges.IEdges<TEdgeData> edges;

        public Graph()
        {
            vertices = new Vertices<TVertexData>();
            edges = new TEdges();
        }

        public int AddVertex(TVertexData data)
        {
            vertices.Add(data);
            return edges.AddVertex();
        }

        public void RemoveVertex(int index)
        {
            vertices.Remove(index);
            edges.RemoveVertex(index);
        }

        public bool IsConnected()
        {
            if (vertices.Count() == 0)
            {
                return true;
            }

            List<bool> used = Enumerable.Repeat(false, vertices.Count()).ToList();
            Queue<int> queue = new();
            int counter = 1;
            used[0] = true;
            queue.Enqueue(0);

            while (queue.Count != 0)
            {
                int vertexOne = queue.Dequeue();
                foreach ((int, TEdgeData) i in edges.GetVertexEdgesEnumerator(vertexOne))
                {
                    if (!used[i.Item1])
                    {
                        counter += 1;
                        if (counter == vertices.Count())
                        {
                            return true;
                        }
                        used[i.Item1] = true;
                        queue.Enqueue(i.Item1);
                    }
                }
            }

            return false;
        }

        public (bool, int) GetDistance(int vertexOne, int vertexTwo)
        {
            List<bool> used = Enumerable.Repeat(false, vertices.Count()).ToList();
            Queue<int> queue = new();
            used[vertexOne] = true;
            queue.Enqueue(vertexOne);
            int distance = 0;
            int lastVertex = vertexOne; // lastVertex with such distance

            while (queue.Count != 0)
            {
                int next = queue.Dequeue();
                if (next == vertexTwo)
                {
                    return (true, distance);
                }

                foreach ((int, TEdgeData) i in edges.GetVertexEdgesEnumerator(next))
                {
                    if (!used[i.Item1])
                    {
                        used[i.Item1] = true;
                        queue.Enqueue(i.Item1);
                    }
                }

                if (next == lastVertex)
                {
                    distance += 1;
                    lastVertex = queue.LastOrDefault();
                }
            }
            return (false, default);
        }
    }
}
