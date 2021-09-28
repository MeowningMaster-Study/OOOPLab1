using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var graph = new Graph.Graph<Graph.Edges.AdjacencyList<object>, int, object>();
            //graph.AddVertex(123);
            //graph.AddVertex(54);
            //graph.edges.Add(0, 1, default);

            Graph.Graph<Graph.Edges.AdjacencyList<object>, int, object> graph = new();
            int v1 = graph.AddVertex(123);
            int v2 = graph.AddVertex(54);
            int v3 = graph.AddVertex(49);
            graph.edges.Add(v1, v3, default);
            graph.edges.Add(v2, v3, default);
            Log(graph.IsConnected().ToString());
            Log(graph.GetDistance(v1, v2).ToString());
        }

        private void Log(string text)
        {
            logsBox.Text += '\n' + text;
        }
    }
}
