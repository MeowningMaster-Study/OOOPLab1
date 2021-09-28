using NUnit.Framework;
using Lab1.Graph;
using Lab1.Graph.Edges;

namespace Lab1Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AdjacencyList()
        {
            Graph<AdjacencyList<object>, int, object> graph = new();
            int v1 = graph.AddVertex(123);
            int v2 = graph.AddVertex(54);
            int v3 = graph.AddVertex(49);
            graph.edges.Add(v1, v3, default);
            graph.edges.Add(v2, v3, default);
            Assert.IsTrue(graph.IsConnected());
            Assert.AreEqual((true, 2), graph.GetDistance(v1, v2));
        }

        [Test]
        public void AdjacencyMatrix()
        {
            Graph<AdjacencyMatrix<object>, int, object> graph = new();
            int v1 = graph.AddVertex(123);
            int v2 = graph.AddVertex(54);
            int v3 = graph.AddVertex(49);
            graph.edges.Add(v1, v3, default);
            graph.edges.Add(v2, v3, default);
            Assert.IsTrue(graph.IsConnected());
            Assert.AreEqual((true, 2), graph.GetDistance(v1, v2));
        }
    }
}