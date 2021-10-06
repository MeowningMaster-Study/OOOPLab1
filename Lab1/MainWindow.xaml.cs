using System.Windows;
using Lab1Libraries.IP;
using Lab1Libraries.SubnetsGraph;

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

            Log("Бесполезный графический интерфейс");
            Log(IPv4.Parse("255.255.255.255/0").ToString());
            Log(IPv6.Parse("::1/0").ToString());
            Log(IPv6.Parse("11:22:F3A3:44:55:C66:77:88/16").HasSubnet(IPv6.Parse("11::0")).ToString());
            Log(IPv4.Parse("255.255.255.255/0").ToIPv6().ToString());

            SubnetsGraph sg = new();
            int a = sg.AddVertex(IPv6.Parse("11:22:F3A3:44:55:C66:77:88/16"));
            int b = sg.AddVertex(IPv6.Parse("11::0"));
            int c = sg.AddVertex(IPv6.Parse("11::A3F:67BC/16"));
            sg.AddSafeEdge(a, b);
            sg.AddSafeEdge(b, c);
            (bool, int) dist = sg.GetDistance(a, c);
            Log("Connected: " + dist.Item1.ToString());
            if (dist.Item1)
            {
                Log("Distance: " + dist.Item2);
            }
        }

        private void Log(string text)
        {
            logsBox.Text += '\n' + text;
        }
    }
}
