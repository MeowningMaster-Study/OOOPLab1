using Lab1Libraries.Graph;
using Lab1Libraries.IP;

namespace Lab1Libraries.SubnetsGraph
{
    public class SubnetsGraph : Graph<Graph.Edges.AdjacencyList<object>, IPv6, object>
    {
        public void AddSafeEdge(int vertexOne, int vertexTwo)
        {
            IPv6 a = vertices[vertexOne];
            IPv6 b = vertices[vertexTwo];
            if (a.HasSubnet(b) || b.HasSubnet(a))
            {
                edges.Add(vertexOne, vertexTwo, default);
            }
        }
    }
}
